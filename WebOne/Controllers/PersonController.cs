using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using WebOne.Models;
using WebOne.ContextDbs;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Configuration;

namespace WebOne.Controllers
{
    public class PersonController : Controller
    {
        private PeopleContext db;

        public PersonController()
        {
            this.db = new PeopleContext();
        }


        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult TestAddtion()
        {
            Person person = new Person()
            {
                FirstName = "Bilal",
                LastName = "Nailun"
            };
            db.People.Add(person);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult ShowList()
        {
            List<Person> PersonLists = new List<Person>();
            string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("ShowAll", con))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            PersonLists.Add(new Person
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                FirstName = sdr["first_name"].ToString(),
                                LastName = sdr["last_name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
                return View(PersonLists);
            }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
    }
}