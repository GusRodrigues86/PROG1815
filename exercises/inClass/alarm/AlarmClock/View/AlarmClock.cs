/* inClass 2
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.02.12: Created
 */
using System;
using System.Globalization;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class GBRAlarmClock : Form
    {
        /// <summary>
        /// Defines if the alarm is armed
        /// </summary>
        private bool IsArmed;
        /// <summary>
        /// The Alarm time
        /// </summary>
        private DateTime AlarmTime;
        /// <summary>
        /// Ticker
        /// </summary>
        private Timer Timer;
        /// <summary>
        /// sound player
        /// </summary>
        private SoundPlayer Player;
        /// <summary>
        /// Is alarm ringing
        /// </summary>
        private bool IsRinging;

        public GBRAlarmClock()
        {
            InitializeComponent();
            lblErrors.Text = "";
            IsArmed = false;
            Timer = new Timer();
            Player = new SoundPlayer();
            IsRinging = false;
        }

        /// <summary>
        /// Load operation. Will start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GBRAlarmClock_Load(object sender, EventArgs e)
        {
            Timer.Interval = 1000; //
            Timer.Tick += new EventHandler(this.Timer_Tick);
            Timer.Start();

        }

        /// <summary>
        /// Every tick of the timer, update the time label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            TimeSpan tolerance = new TimeSpan(0, 0, 4);
            var pastAlarm = ((DateTime.Now - AlarmTime) >= tolerance);
            var futureAlarm = ((AlarmTime - DateTime.Now) >= tolerance);

            if (IsArmed)
            {
                if (!futureAlarm && !pastAlarm)
                {
                    IsRinging = true;
                    PlayAlarm(sender, e);
                }
            }
            if (IsRinging)
            {
                PlayAlarm(sender, e);
            }
        }

        #region Validation

        /// <summary>
        /// Verify if the user provided input is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateTime(object sender, EventArgs e)
        {
            Regex timeRegex = new Regex(@"^[0-1][0-9][:][0-5][0-9]",
                RegexOptions.IgnoreCase);
            string timeInput = txtAlarmTimer.Text;
            // clear errors
            lblErrors.Text = "";
            if (timeInput.Equals("  :  ")) // empty time format by masked textbox
            {
                lblErrors.Text += "The format is in 12 hour HH:MM\r\n";
                IsArmed = false;
                return;
            }
            else
            {
                timeInput = timeInput.Trim();
                if (!timeRegex.IsMatch(timeInput))
                {
                    IsArmed = false;
                    lblErrors.Text += "The format is in 12 hour HH:MM\r\n";
                }
            }

            // validate combobox for am/pm
            if (comboAmPm.SelectedItem is null)
            {
                lblErrors.Text += "AM or PM?";
            }
        }
        #endregion

        #region Change Alarm State
        /// <summary>
        /// Changes the Alarm state. It only arms if the information provided is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeAlarmState(object sender, EventArgs e)
        {
            // disable the alarm
            if (IsArmed)
            {
                SilenceAlarm();
                IsArmed = false;
                checkActive.Checked = false;
            }

            // Sanity validation
            ValidateTime(sender, e);

            // if is not ok, stop and disarm
            if (!String.IsNullOrWhiteSpace(lblErrors.Text))
            {
                checkActive.Checked = false;
                IsArmed = false;
                return;
            }

            // Create a date time based on the user input
            AlarmTime = DateTime.ParseExact($"{txtAlarmTimer.Text} " +
                $"{comboAmPm.SelectedItem.ToString()}",
                "hh:mm tt", // used format
                CultureInfo.InvariantCulture);

            // if AlarmTime >= Current Time + 3s, arm.
            if (AlarmTime.CompareTo(DateTime.Now.AddSeconds(3)) >= 0)
            {
                IsArmed = true;
            }

        }
        #endregion

        private void PlayAlarm(object sender, EventArgs e)
        {
            Player.SoundLocation = @"c:\windows\media\Windows Logoff Sound.wav";
            Player.Play();
        }

        /// <summary>
        /// Quiets the alarm ftfs.
        /// </summary>
        private void SilenceAlarm() =>
            Player.Stop();

        /// <summary>
        /// Disable the alarm and force the player to stop if playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopAlarm(object sender, EventArgs e)
        {
            SilenceAlarm();
            IsRinging = false;
        }

        /// <summary>
        /// MessageBox containing about me
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            string author = "Written and designed by Gustavo Bonifacio Rodrigues\r\n" +
            MessageBox.Show(author, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
