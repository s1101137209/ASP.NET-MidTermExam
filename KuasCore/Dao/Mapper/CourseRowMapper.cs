using KuasCore.Models;
using Spring.Data.Generic;
using System.Data;

namespace KuasCore.Dao.Mapper
{
    class CourseRowMapper : IRowMapper<Course>
    {
        public Course MapRow(IDataReader dataReader, int rowNum)
        {
            Course target = new Course();

            target.ID = dataReader.GetString(dataReader.GetOrdinal("Id"));
            target.NAME = dataReader.GetString(dataReader.GetOrdinal("Name"));
            target.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));

            return target;
        }
    }
}
