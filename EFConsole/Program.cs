using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CompanyContext companyContext = new CompanyContext();

                var member = new Member { Address = "add1", FirstName = "first1", Lastname = "last1" };
                var team = new Team() { Description = "desc1", Name = "name1" };
                team.Members.Add(member);
                companyContext.Teams.Add(team);

                companyContext.SaveChanges();



                Console.WriteLine("");
                Console.WriteLine("*******************************************************************");
                foreach (var team1 in companyContext.Teams)
                {
                    Console.Write("teamID:{0}, team-memberID:{1}",
                        team1.Id,
                        team1.Members.First().Id);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            Console.Read();
        }
    }

    public class CompanyContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
    }

    public class Team
    {
        public Team()
        {
            Members = new List<Member>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<Member> Members { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public Team Team { get; set; }
    }
}
