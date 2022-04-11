namespace Vueling.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return this.Name.ToString() + "," + this.Surname.ToString();
        }
    }
}
