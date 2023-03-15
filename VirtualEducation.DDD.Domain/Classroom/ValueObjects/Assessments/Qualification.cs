namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment
{
    public class Qualification
    {
        //variables
        public int Rating { get; init; }
        public string Feedback { get; init; }


        //constructor
        public Qualification(int rating, string feedback)
        {
            Rating = rating;
            Feedback = feedback;
        }


        //create method
        public static Qualification Create(int rating, string feedback)
        {
            Validate(rating, feedback);
            return new Qualification(rating, feedback);
        }
        //validate method
        public static void Validate(int rating, string feedback)
        {
            if (rating.Equals(null))
            {
                throw new ArgumentNullException("Rating cannot be null");
            }
            if (feedback.Equals(null))
            {
                throw new ArgumentNullException("Feedback cannot be null");
            }
        }
    }
}
