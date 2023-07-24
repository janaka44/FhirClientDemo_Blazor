using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class PeopleData
    {
        private readonly ISQLDataAccess _db;

        public PeopleData(ISQLDataAccess db)
        {
            this._db = db;
        }

        public  Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.Poeple";

        }
    }
}
