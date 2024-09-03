using System.Dynamic;
using System.Net;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Patient
{
    private string name;
    public Patient(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
    return name; 
    }
}

class Doctor
{
    private string doctor;
    public Doctor(string doctor)
    {
        this.doctor = doctor;
    }
}

class Chamber
{
    private int chamber;
    private List<Patient> patients;

    public Chamber(int chamber)
    {
        this.chamber = chamber;
        patients = new List<Patient>();
    }
    public bool AddPatient(Patient patient)
    {
        if (patients.Count < 3)
        {
            patients.Add(patient);
            return true;
        }
        return false;
    }

    public List<Patient> GetPatients()
    {
        return patients;
    }

}

class Department
{
    private string name;
    private List<Chamber> chambers;

    public Department(string name)
    {
        this.name = name;
        chambers = new List<Chamber>();
        for(int i = 1; i <= 20; i++)
        {
            chambers.Add(new Chamber(i));
        }
    }

    public bool AddPatient(int Number, Patient patient)
    {
        if (Number < 1 || Number > 20)
        {
            return false;
        }
        return chambers[Number - 1].AddPatient(patient);
    }

    public string GetDepartament()
    {
        return name;
    }

    public List<Patient> GetPatients()
    {
        List<Patient> amount = new List<Patient>();
        for (int i = 0; i < chambers.Count; i++)
        {
            List<Patient> patients = chambers[i].GetPatients();
            for (int j = 0; j < patients.Count; j++)
            {
                amount.Add(patients[j]);
            }
        }
        return amount;
    }

}

class Hospital
{
    private List<Department> departments;

    public Hospital()
    {
        departments = new List<Department>();
    }

    public void AddDepartment(Department department)
    {
        departments.Add(department);
    }

    public Department GetDepartment(string name)
    {
        for (int i = 0; i < departments.Count; i++)
        {
            if (departments[i].GetDepartament() == name)
            {
                return departments[i];
            }
        }
        return null;
    }
}


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<Hospital> hospitals = new List<Hospital>();

        string command1 = null;
        while ((command1 = Console.ReadLine()) != "Output")
        {
            string[] input = command1.Split(' ');
            string department = input[0];
            string doctor = input[1];
            string patient = input[2];

            Hospital hospital = null;
            for(int i = 0; i < hospitals.Count; i++)
            {
                if (hospitals[i].GetDepartment(department) != null)
                {
                    hospital = hospitals[i];
                }
            }

            if (hospital == null)
            {
                hospital = new Hospital();
                hospitals.Add(hospital);
            }

            Department DEPARTMENT = hospital.GetDepartment(department);
            if (DEPARTMENT == null)
            {
                DEPARTMENT = new Department(department);
                hospital.AddDepartment(DEPARTMENT);
            }

            Doctor DOCTOR = new Doctor(doctor);

            Patient PATIENT = new Patient(patient);
            DEPARTMENT.AddPatient(1, PATIENT);
        }

        string command2 = null;
        while((command2 = Console.ReadLine()) != "End")
        {
            for (int i = 0; i < hospitals.Count; i++)
            {
                Department DEPARTMENT = hospitals[i].GetDepartment(command2);
                if (DEPARTMENT != null)
                {
                    List<Patient> patients = DEPARTMENT.GetPatients();
                    for (int j = 0; j < patients.Count; j++)
                    {
                        Console.WriteLine(patients[j].GetName());
                    }
                    break;
                }
            }
        }
    }
}

/*
Cardiology Petar Ventsi
Oncology Ivaylo Valio
Emergency Mariq Simo
Cardiology Genka Simon
Emergency Ivaylo Kenov
Cardiology Gosho Esmeralda
Oncology Gosho Cleopatra
Output
Cardiology
 
 */
