using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Task3.Models
{
    public class EmployeeMethods
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-V5POTD0;Initial Catalog=Lec2;Integrated Security=True");
        static string query = "";
        static SqlCommand command;

        public static List<Employee> GetEmployees()
        {
            List<Employee> emplyees = new List<Employee>();
            Employee employee = null;
            query = "SELECT * FROM Employees";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employee = new Employee();
                employee.ID = (int)reader[0];
                employee.Name = reader[1].ToString();
                try
                {
                    employee.Salary = (int)reader[2];
                }
                catch (Exception)
                {
                    employee.Salary = null;
                }
                try
                {
                    employee.IsMarried = (bool)reader[3];
                }
                catch (Exception)
                {
                    employee.IsMarried = null;
                }
                emplyees.Add(employee);
            }
            connection.Close();
            return emplyees;
        }

        public static int GetSumOfSalaries()
        {
            int sum = 0;
            query = "SELECT SUM(Salary) FROM Employees";
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                sum = (int)command.ExecuteScalar();
            }
            catch (Exception)
            {
                return sum;
            }
            connection.Close();
            return sum;
        }

        public static Employee GetEmployee(int id)
        {
            Employee employee = null;
            query = "SELECT * FROM Employees WHERE (ID = " + id + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employee = new Employee();
                employee.ID = (int?)reader[0];
                employee.Name = reader[1].ToString();
                try
                {
                    employee.Salary = (int?)reader[2];
                }
                catch (Exception)
                {
                    employee.Salary = null;
                }
                try
                {
                    employee.IsMarried = (bool?)reader[3];
                }
                catch (Exception)
                {
                    employee.IsMarried = null;
                }
            }
            connection.Close();
            return employee;
        }

        public static void InsertEmployee(Employee employee)
        {
            query = "INSERT INTO Employees (Name, Salary, IsMarried) VALUES (N'" + employee.Name + "', " + employee.Salary + ", " + Convert.ToInt32(employee.IsMarried) + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertEmployeeName(string name)
        {
            query = "INSERT INTO Employees (Name) VALUES ('" + name + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertEmployeeNameStatus(string name, bool is_married)
        {
            query = "INSERT INTO Employees (Name, IsMarried) VALUES (N'" + name + "', " + Convert.ToInt32(is_married) + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateEmployeeData(int id, Employee employee)
        {
            query = "UPDATE Employees SET Name = '" + employee.Name + "', Salary = " + employee.Salary + ", IsMarried = " + Convert.ToInt32(employee.IsMarried) + " WHERE (ID = " + id + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateEmployeeSalary(int id, int salary)
        {
            query = "UPDATE Employees SET Salary = " + salary + " WHERE (ID = " + id + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateMarriedSalaries()
        {
            query = "UPDATE Employees SET Salary = Salary + 200 WHERE (IsMarried = 1)";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteNullSalaries()
        {
            query = "delete from Employees where ISNULL(Salary, '')=''";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteEmployeeData(int id)
        {
            query = "DELETE FROM Employees WHERE (ID = " + id + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteAllEmployees()
        {
            query = "DELETE FROM Employees";
            command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}