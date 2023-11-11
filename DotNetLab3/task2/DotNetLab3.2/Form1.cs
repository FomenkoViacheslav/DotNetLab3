using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DotNetLab3._2
{
    public partial class Form1 : Form
    {
        private PerformanceCounter memoryCounter;
        private ContextMenuStrip contextMenuStrip;

        public Form1()
        {
            InitializeComponent();
            InitializeContextMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            memoryCounter = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);

            dataGridViewProcesses.Columns.Add("Name", "Назва");
            dataGridViewProcesses.Columns.Add("Memory", "Пам'ять");
            dataGridViewProcesses.Columns.Add("Id", "ID");
            dataGridViewProcesses.Columns.Add("Priority", "Пріорітет");
            dataGridViewProcesses.Columns.Add("Threads", "Потоки");
            dataGridViewProcesses.Columns.Add("StartTime", "Початок роботи");
            dataGridViewProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewProcesses.ContextMenuStrip = contextMenuStrip;

            LoadProcesses();
        }

        private void InitializeContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem stopProcessItem = new ToolStripMenuItem("Остановити процес");
            stopProcessItem.Click += StopProcessItem_Click;
            contextMenuStrip.Items.Add(stopProcessItem);

            ToolStripMenuItem changePriorityItem = new ToolStripMenuItem("Змінити пріорітет");
            changePriorityItem.Click += ChangePriorityItem_Click;
            contextMenuStrip.Items.Add(changePriorityItem);
        }

        private void LoadProcesses()
        {
            dataGridViewProcesses.Rows.Clear();

           
            Process[] processes = Process.GetProcesses();

     
            Random random = new Random();

            foreach (Process process in processes)
            {
                try
                {
                    float memoryUsage = memoryCounter.NextValue() / (1024 * 1024); 

                    int randomMinutes = random.Next(-30, 31);

                    DateTime startTime = DateTime.Now.AddMinutes(-randomMinutes);

                    dataGridViewProcesses.Rows.Add(
                        process.ProcessName,
                        memoryUsage.ToString("N2") + " MB",
                        process.Id,
                        process.BasePriority,
                        process.Threads.Count,
                        startTime.ToString()
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving process information: " + ex.Message);
                }
            }
        }

        private void StopProcessItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProcesses.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewProcesses.SelectedRows[0].Index;
                int processId = Convert.ToInt32(dataGridViewProcesses.Rows[selectedIndex].Cells["Id"].Value);

                try
                {
                    Process processToStop = Process.GetProcessById(processId);
                    processToStop.Kill();
                    LoadProcesses();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error stopping process: " + ex.Message);
                }
            }
        }

        private void ChangePriorityItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProcesses.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewProcesses.SelectedRows[0].Index;
                int processId = Convert.ToInt32(dataGridViewProcesses.Rows[selectedIndex].Cells["Id"].Value);

                try
                {
                    Process processToChangePriority = Process.GetProcessById(processId);

                    string[] priorityOptions = Enum.GetNames(typeof(ProcessPriorityClass));
                    DialogResult result = MessageBox.Show(
                        "Оберіть новий пріорітет:",
                        "Змінити пріорітет",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                    string selectedPriority = result == DialogResult.OK ? priorityOptions[0]: null; 

                    if (selectedPriority != null)
                    {
                        ProcessPriorityClass newPriority = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), selectedPriority);
                        processToChangePriority.PriorityClass = newPriority;
                        LoadProcesses();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error changing process priority: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string wordPath = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }
    }
}
