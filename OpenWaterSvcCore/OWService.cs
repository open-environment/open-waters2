using OpenWater2.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWaterSvcCore
{
    public class OWService
    {
        private Timer TSubmitTimer = null;
        private Timer TSubmitStatusTimer = null;
        private IUnitOfWork _unitOfWork;


        public OWService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Start()
        {
            // write code here that runs when the Windows Service starts up.  
            Utils.WriteToFile("Open Waters Task Service started");

            try
            {
                //Reset the service status so it will run again (in case it failed previously)
                int SuccID = await _unitOfWork.oeAppTasksRepository.UpdateT_OE_APP_TASKSAsync("WQXSubmit", "STOPPED", null, "TASK");
                if (SuccID > 0)
                {
                    TSubmitTimer = new Timer(
                        new TimerCallback(SubmitTickTimerAsync),
                        null,
                        2000,
                        (1000 * 60) * 1);
                    TSubmitStatusTimer = new Timer(
                        new TimerCallback(SubmitStatusTickTimeAsync),
                        null,
                        5000,
                        (1000 * 10));
                    Utils.WriteToFile("*************************************************");
                    Utils.WriteToFile("Open Waters Task Service timer successfully initialized");
                    Utils.WriteToFile("*************************************************");
                    //Utils.WriteToFile("Open Waters Task Service timer set to run every " + timer.Interval + " ms");
                }
                else
                {
                    Utils.WriteToFile("Unable to reset service");
                }

            }
            catch (Exception ex)
            {
                Utils.WriteToFile("Failed to start Open Waters Service - Unspecified error. " + ex.Message);
            }
        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
            Utils.WriteToFile("Open Waters Task has stopped");
            TSubmitTimer.Change(
                       Timeout.Infinite,
                       Timeout.Infinite);
        }

        private async void SubmitTickTimerAsync(object state)
        {
            Console.Write("[Submit] >> Submit Tick! ");
            Console.WriteLine(
                Thread.CurrentThread.
                ManagedThreadId.ToString());
            Thread.Sleep(4000);
            try
            {
                //Utils.WriteToFile("Open Waters Submission Task Started");
                Console.WriteLine("[Submission] > Submission Task: Started!");
                //submitting any pending data to EPA
                await _unitOfWork.tWqxSubmitRepository.WQX_MasterAllOrgsAsync();
                //WQXSubmit.WQX_MasterAllOrgs();


                //importing activity data from EPA
                // WQXSubmit.ImportActivityMaster();
                //Utils.WriteToFile("Open Waters Submission Task Ended");
                Console.WriteLine("Submission Task: Ended!");
                //TTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception e)
            {
                Utils.WriteToFile("ERROR getting execution time information from database.");
            }
        }
        private async void SubmitStatusTickTimeAsync(object state)
        {
            Console.Write("[Status] >> Status Tick! ");
            Console.WriteLine(
                Thread.CurrentThread.
                ManagedThreadId.ToString());
            Thread.Sleep(4000);
            try
            {
                //Utils.WriteToFile("Open Waters Submission Task Started");
                Console.WriteLine("[Status] >> Submit Status Task: Started!");
                //submitting any pending data to EPA
                _ = await _unitOfWork.tWqxSubmitRepository.WQX_MasterAllOrgsTaskStatusAsync();
                //WQXSubmit.WQX_MasterAllOrgs();


                //importing activity data from EPA
                // WQXSubmit.ImportActivityMaster();
                //Utils.WriteToFile("Open Waters Submission Task Ended");
                Console.WriteLine("Submit Status Task: Ended!");
                //TTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception e)
            {
                Utils.WriteToFile("ERROR getting execution time information from database.");
            }
        }
        
    }
}
