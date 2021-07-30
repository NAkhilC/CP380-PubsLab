using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CP380_PubsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbcontext = new Models.PubsDbContext())
            { 
                if (dbcontext.Database.CanConnect())
                {
                    Console.WriteLine("Yes, I can connect");
                }
                List<JOBDET> det = new List<JOBDET>();
                List<EMPDET> emp = new List<EMPDET>();
                foreach (var b in dbcontext.Jobs)
                {
                    det.Add(new JOBDET() { Desc = b.Desc, Id = b.Id});
                }
                foreach (var b in dbcontext.Employee)
                {
                    emp.Add(new EMPDET() { Fname = b.Fname, Lname = b.Lname, jid = b.Job_Id });
                }

                foreach (var a in dbcontext.Employee)
                {
                    foreach (var b in det)
                    {
                        if (b.Id == a.Job_Id)
                        {
                          Console.WriteLine(a.Id+" -  "+b.Desc);
                        }
                       
                    }

                }

                foreach (var a in dbcontext.Jobs)
                {
                    Console.WriteLine("-----**"+a.Id+"**----------");
                    foreach (var b in emp)
                    {
                        if (b.jid == a.Id)
                        {
                            Console.WriteLine(b.Fname+" "+b.Lname);
                        }

                    }

                }


                List<SALDET> sal = new List<SALDET>();
                List<TITDET> Titledata = new List<TITDET>();


                foreach (var b in dbcontext.Titles.Include(a => a.Salesli))
                {
                    sal.Add(new SALDET() { Salesid = b.Salesli.SId, title = b.title });
                }
                foreach (var b in dbcontext.Stores.Include(a => a.Salesli))
                {
                    Titledata.Add(new TITDET() { Salesid = b.Salesli.TId, name = b.name });
                }

                foreach (var a in dbcontext.Stores)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(a.name + "------>>>>>>");
                    foreach (var b in sal)
                    {
                        if (b.Salesid == a.Salesli.SId)
                        {
                            Console.WriteLine(b.title);
                        }

                    }
                }

                foreach (var a in dbcontext.Titles)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(a.title + "------>>>>>>");
                    foreach (var b in Titledata)
                    {
                        if (b.Salesid == a.Id)
                        {
                            Console.WriteLine(b.name);
                        }

                    }
                }

                




                // Many:many practice
                //
                // TODO: - Loop through each Store
                //       - For each store, list all the titles sold at that store
                //
                // e.g.
                //  Bookbeat -> The Gourmet Microwave, The Busy Executive's Database Guide, Cooking with Computers: Surreptitious Balance Sheets, But Is It User Friendly?

                // TODO: - Loop through each Title
                //       - For each title, list all the stores it was sold at
                //
                // e.g.
                //  The Gourmet Microwave -> Doc-U-Mat: Quality Laundry and Books, Bookbeat
            }
        }
    }
}
