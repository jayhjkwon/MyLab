using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitDatabase();
        }

        private void InitDatabase()
        {
            ActiveRecordStarter.ResetInitializationFlag();
            
            // #1 using xml file
            //IConfigurationSource source = new XmlConfigurationSource("ConnectionInfo.xml");

            // #2 using code
            IDictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("connection.driver_class", "NHibernate.Driver.SQLiteDriver");
            properties.Add("dialect", "NHibernate.Dialect.SQLiteDialect");
            properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            properties.Add("connection.connection_string", "Data Source=CompanyDatabase.db;Version=3"); 
            properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
            properties.Add("show_sql", "true");

            var source = new InPlaceConfigurationSource();
            source.Add(typeof(ActiveRecordBase), properties);

            ActiveRecordStarter.Initialize(source, typeof (Team), typeof (Member));

            //ActiveRecordStarter.DropSchema();
            ActiveRecordStarter.CreateSchema();
        }

        // save team event
        private void Button2Click(object sender, EventArgs e)
        {
            var team = new Team {Name = tbTeamName.Text.Trim(), Description = tbDescription.Text.Trim()};
            team.SaveAndFlush();

            ShowTeam();

            if (dataGridViewTeam == null || dataGridViewTeam.Rows.Count <= 0) return;

            // focus on the last row in dataGridViewTeam
            for (int i = dataGridViewTeam.Rows.Count - 1; i >= 0; i--)
            {
                dataGridViewTeam.Rows[i].Selected = false;
            }
            dataGridViewTeam.Rows[dataGridViewTeam.Rows.Count-1].Selected = true;
        }

        // search team event
        private void Button1Click(object sender, EventArgs e)
        {
            ShowTeam();
        }

        private void ShowTeam()
        {
            using (new SessionScope())
            {
                var teams = Team.FindAll();
                dataGridViewTeam.DataSource = teams;
                if (teams != null && teams.Count() > 0)
                    dataGridViewMember.DataSource = teams[0].Members;
            }
        }
        
        // delete team event
        private void Button3Click(object sender, EventArgs e)
        {
            var teamId = GetSelectedTeamId();
            if (teamId < 0) return;

            var team = Team.Find(teamId);
            team.Delete();

            ShowTeam();
        }

        // dataGridViewTeam selection change event
        private void DataGridViewTeamSelectionChanged(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridViewTeam.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0) return;
            
            var selectedRow = dataGridViewTeam.SelectedRows[selectedRowCount - 1];
            
            var teamId = selectedRow.Cells[0].Value.ToString();
            var teamName = selectedRow.Cells[1].Value.ToString();
            var teamDescription = selectedRow.Cells[2].Value.ToString();

            tbTeamName.Text = teamName;
            tbDescription.Text = teamDescription;

            ShowMembers(int.Parse(teamId));
        }

        // save member event
        private void Button5Click(object sender, EventArgs e)
        {
            var teamId = GetSelectedTeamId();
            if (teamId < 0) return;

            var member = new Member()
                             {
                                 Address = tbAddress.Text.Trim(),
                                 FirstName = tbFirstName.Text.Trim(),
                                 Lastname = tbLastName.Text.Trim(),
                                 Team = Team.Find(teamId)
                             };
            member.SaveAndFlush();

            ShowMembers(teamId);
        }

        // bind members to dataGridViewMembers
        private void ShowMembers(int teamId)
        {
            var members = Member.FindAllByProperty("Team", Team.Find(int.Parse(teamId.ToString())));
            dataGridViewMember.DataSource = members;
        }

        // delete member event
        private void Button4Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridViewMember.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount <= 0) return;

            var memberId = dataGridViewMember.SelectedRows[selectedRowCount - 1].Cells[0].Value;

            var member = Member.Find(int.Parse(memberId.ToString()));
            member.Delete();

            ShowMembers(GetSelectedTeamId());
        }

        // get teamId from selected row in dataGridViewTeam
        private int GetSelectedTeamId()
        {
            Int32 selectedRowCount = dataGridViewTeam.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0) return -1;

            var selectedRow = dataGridViewTeam.SelectedRows[selectedRowCount - 1];

            var teamId = selectedRow.Cells[0].Value.ToString();

            return int.Parse(teamId.ToString());
        }

        // lazy loading test
        private void button6_Click(object sender, EventArgs e)
        {
            // Lazy Loading only work in session scope!! 
            // this means you always need to enclose the code in SessionScope
            using (new SessionScope())
            {
                // "select * from teams" query will be executed
                var teams = Team.FindAll();

                // nothing happened
                var members = teams[0].Members;

                // "select * from members" query will be executed 
                Console.Write(members[0].Id);    
            }
            

        }

        // transaction test
        private void button8_Click(object sender, EventArgs e)
        {
            using (var tx = new TransactionScope())
            {
                try
                {
                    var team1 = new Team();
                    team1.Name = "team1";
                    team1.Description = "desc1";
                    team1.Save();

                    // throw exeception to check tx
                    throw new Exception();

                    var team2 = new Team();
                    team2.Name = "team2";
                    team2.Description = "desc2";
                    team2.Save();
                }
                catch 
                {
                    tx.VoteRollBack();   
                }
            }
        }

        // search all the members
        private void button7_Click(object sender, EventArgs e)
        {
            var members = Member.FindAll();
            dataGridViewMember.DataSource = members;
        }

        
        
    }
}
