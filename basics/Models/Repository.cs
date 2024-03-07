namespace basics.Models{
    public class Repository{
        private static readonly List<Course> _courses = new();

        static Repository(){
            _courses = new List<Course>(){
                new Course() {
                    Id = 1, 
                    Title = "AspNet Kursu",
                    Description = "AspDotNet öğrenmek için güzel bir kurs",
                    Image = "1.png",
                    Tags = new string[] {"aspdotnet","web geliştirme"},
                    isActive = true,
                    isHome = true
                },
                new Course() {
                    Id = 2, 
                    Title = "Spring Boot Kursu",
                    Description = "Spring Boot öğrenmek için güzel bir kurs",
                    Image = "2.png",
                    Tags = new string[] {"spring boot","web geliştirme", "java"},
                    isActive = true,
                    isHome = false
                },
                new Course() {
                    Id = 3, 
                    Title = "Node.Js Kursu",
                    Description = "Node.Js öğrenmek için güzel bir kurs",
                    Image = "3.png",
                    isActive = false,
                    isHome = true
                }
            };
        }

        public static List<Course> Courses{
            get{
                return _courses;
            }
        }

        public static Course? GetById(int id){
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}