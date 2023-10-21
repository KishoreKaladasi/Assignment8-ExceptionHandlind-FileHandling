using System;
using Eception_File_Handling;

 

class FirstMain
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Write the employee Id");
            int w = Convert.ToInt32(Console.ReadLine());    
            Console.WriteLine("Write the employee name");
            string x = Console.ReadLine();  
            Console.WriteLine("Write the employee salary");
            double y = Convert.ToDouble(Console.ReadLine());        
            Console.WriteLine("Write the employee deptNo");
            int z = Convert.ToInt32(Console.ReadLine());

            Employee emp1 = new Employee(w,x,y,z);
             
             
        }
        catch (InvalidEmployeeDataException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        
        Console.WriteLine("Employee created successfully!");
        Console.Read();
    }
    
}