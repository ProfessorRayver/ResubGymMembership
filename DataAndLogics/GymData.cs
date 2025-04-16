using System.Collections.Generic;

public class GymData
{
        public List<Member> Members = new List<Member>();

     public List<string> WorkoutRoutines = new List<string> {
        "Chest Day: Bench Press, Push-ups, Dumbbell Flyes",
        "Back Day: Deadlifts, Pull-ups, Lat Pulldowns",
        "Leg Day: Squats, Lunges, Leg Press",
        "Arm Day: Bicep Curls, Triceps Dips, Hammer Curls",
        "Shoulder Day: Overhead Press, Lateral Raises, Face Pulls",
        "Cardio: Running, Cycling, Jump Rope"
    };

     public class Member
    {
        public string Name;
        public string MembershipType;
        public string Month;
        public string PaymentStatus;

        public Member(string name, string membershipType, string month)
        {
            Name = name;
            MembershipType = membershipType;
            Month = month;
            PaymentStatus = "paid";
        }
    }
}
