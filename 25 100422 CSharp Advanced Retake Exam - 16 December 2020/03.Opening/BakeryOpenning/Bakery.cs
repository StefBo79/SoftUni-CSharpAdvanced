using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (Capacity >= data.Count + 1)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    data.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);
            return employee;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString();
        }
    }
}