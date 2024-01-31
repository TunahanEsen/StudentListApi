using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web.api.student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static private List<Student> StudentList = new List<Student>
        {
            new Student { Id = 1,FirstName="Denemeisim1",LastName="Denemesoyisim1"},
            new Student { Id = 2,FirstName="Denemeisim2",LastName="Denemesoyisim2"},
            new Student { Id = 3,FirstName="Denemeisim3",LastName="Denemesoyisim3"},
            new Student { Id = 4,FirstName="Denemeisim4",LastName="Denemesoyisim4"},
            new Student { Id = 5,FirstName="Denemeisim5",LastName="Denemesoyisim5"},
            new Student { Id = 6,FirstName="Denemeisim6",LastName="Denemesoyisim6"},
            new Student { Id = 7,FirstName="Denemeisim7",LastName="Denemesoyisim7"},
            new Student { Id = 8,FirstName="Denemeisim8",LastName="Denemesoyisim8"}
        };

        [HttpGet]
        public IEnumerable<Student> StudentGet()
        {
            return StudentList;
        }

        [HttpGet("{id}")]
        public Student? StudentGetId(int id)
        {
            var student = StudentList.Find(a => a.Id == id);

            return student;
        }

        [HttpPost]
        public void StudentPost(string FirstName, string LastName)
        {
            var newStudent = new Student { FirstName = FirstName, LastName = LastName, Id = StudentList.Count + 1 };

            StudentList.Add(newStudent);
        }

        [HttpPut("{id}")]
        public void StudentPut(int id, string _FirstName, string _LastName)
        {
            var index = StudentList.FindIndex(a => a.Id == id);

            if (index == -1)
            {
                return;
            }
            StudentList[index] = new Student { FirstName = _FirstName, LastName = _LastName, Id = id };
        }

        [HttpDelete("{id}")]
        public void StudentDelete(int id)
        {
            var index = StudentList.FindIndex(a => a.Id == id);

            if (index == -1)
            {
                return;
            }

            StudentList.RemoveAt(index);
        }
    }
}

