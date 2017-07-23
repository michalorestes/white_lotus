/*
Users class is used to add and load information 
about this application's user, uncluding clients, instructors, 
managers and administrators
This class will usually need to be used with DBconnection class. 


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteLotus_mainCW
{
    public class User
    {
        //** FIELDS **//
        private int id;
        private string name;
        private string DOB;
        private string experience;
        private string health;
        private string email;
        private long telNo;
        private string password;
        private bool anusara;
        private bool bikram;
        private bool hatha;
        private string admin; 

        //** PROPERTIES ** //
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string DateOfBirth
        {
            set { DOB = value; }
            get { return DOB; }
        }

        public string Experience
        {
            set { experience = value; }
            get { return experience; }
        }

        public string Health
        {
            set { health = value; }
            get { return health; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public long TelNo
        {
            set { telNo = value; }
            get { return telNo; }
        }

        public string Admin
        {
            set { admin = value; }
            get { return admin; }
        }

        public bool Anusara
        {
            get
            {
                return anusara;
            }

            set
            {
                anusara = value;
            }
        }

        public bool Bikram
        {
            get
            {
                return bikram;
            }

            set
            {
                bikram = value;
            }
        }

        public bool Hatha
        {
            get
            {
                return hatha;
            }

            set
            {
                hatha = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public User(string name, string DOB, string experience, string health, string email, long telNo, string password, string admin)
        {
            
            this.name = name;
            this.DOB = DOB;
            this.experience = experience;
            this.health = health;
            this.telNo = telNo;
            this.password = password;
            this.email = email;
            this.admin = admin;

        }//End of USER constructor 


        public User(string name, string DOB, string experience, string health, bool anusara, bool bikram, bool hatha, string email, long telNo, string password, string admin)
        {
            this.name = name;
            this.DOB = DOB;
            this.experience = experience;
            this.anusara = anusara;
            this.bikram = bikram;
            this.hatha = hatha;
            this.health = health;
            this.telNo = telNo;
            this.password = password;
            this.email = email;
            this.admin = admin;

        }//End of USER constructor 


        //empty constructor used for loading data from a databse. 
        public User()
        {

        }
         
        //used for testing only 
        public string introduction()
        {
            string myIntroduction = name + " " + DOB + " " + experience + " " + health + " " + telNo + " " + email + " " + password; 


            return myIntroduction;
        }



    }


    

}