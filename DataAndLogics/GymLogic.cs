using System.Collections.Generic;

public class GymLogic
{
    private GymData data = new GymData();

    public void AddMember(string name, string membershipType, string month)
    {
        data.Members.Add(new GymData.Member(name, membershipType, month));
    }

    public void RemoveMember(string name)
    {
        name = name.ToLower();
        for (int i = 0; i < data.Members.Count; i++)
        {
            if (data.Members[i].Name.ToLower() == name)
            {
                data.Members.RemoveAt(i);
                break;
            }
        }
    }

    public List<GymData.Member> GetMembers()
    {
        return data.Members;
    }

    public List<string> GetWorkoutRoutines()
    {
        return data.WorkoutRoutines;
    }

    public bool UpdatePaymentStatus(string name, string status, string validMonth)
    {
        name = name.ToLower();
        foreach (var member in data.Members)
        {
            if (member.Name.ToLower() == name)
            {
                member.PaymentStatus = status;
                member.Month = validMonth;
                return true;
            }
        }
        return false;
    }

    public string SearchMemberStatus(string name)
    {
        name = name.ToLower(); 
        foreach (var member in data.Members)
        {
            if (member.Name.ToLower() == name) 
            {
                return $"Name: {member.Name}, Payment Status: {member.PaymentStatus}";
            }
        }
        return "Member not found.";
    }
}
