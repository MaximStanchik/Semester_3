using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Excep;

namespace List
{
    public class Production
    {
        private int id;
        private string organization;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public Production()
        {
            organization = "unknown";
            id = 0;
        }
        public Production(string Organization)
        {
            organization = Organization;
            id = GetHashCode();
        }
        public override int GetHashCode()
        {
            var hash = 0;
            foreach (char temp in organization)
            {
                hash += Convert.ToInt32(temp);
            }
            return Convert.ToInt32(hash);
        }
    }
    public class Node<T>
    {
        public T val;
        public Node<T> next;

        public Node(T value)
        {
            val = value;
            next = null;
        }
        public T Val
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
        public Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }

    public class List<T>
    {
        public Node<T> head;
        public Node<T> lastNode;
        private int count = 0;
        private Production production1 = new Production("belstu");

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public List()
        {
            head = null;
            lastNode = null;
            count = 0;
        }

        public void addNode(T val)
        {
            if (val == null)
            {
                throw new NULLException("вы ничего не передали!", val);
            }
            Node<T> newNode = new Node<T>(val);
            if (head == null)
            {
                head = newNode;
                lastNode = newNode;
            }
            else
            {
                lastNode.next = newNode;
                lastNode = newNode;
            }
            count++;
        }

        Node<T> findNode(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Val.Equals(value))
                    return current;
                else
                    current = current.next;
            }
            return null;
        }
        private Node<T> findPreviousNode(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.next.Val.Equals(value))
                    return current;
                else
                    current = current.next;
            }
            return null;
        }
        public static List<T> Load()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mylist.bin");
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    return (List<T>)binaryFormatter.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке списка: " + ex.Message);
                return null;
            }
        }
        public void SaveToFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mylist.bin");
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, this);
                }
                Console.WriteLine("Список успешно сохранен в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении списка: " + ex.Message);
            }
        }
        void Remove(T value)
        {
            Node<T> RemoveNode = findNode(value);
            Node<T> PreviousenNode = findPreviousNode(value);
            if (RemoveNode.Equals(head))
            {
                if (head.next != null)
                {
                    head = null;
                    count--;
                    return;
                }
                head = RemoveNode.next;
                count--;
                return;
            }
            if (RemoveNode != null && PreviousenNode != null)
            {
                PreviousenNode.next = RemoveNode.next;
                RemoveNode.next = null;
            }
            throw new NothingToDelete("Нету элемента для удаления");
        }
        public void Display()
        {
            Node<T> current = this.head;
            while (current != null)
            {
                Console.Write(current.Val + "->");
                current = current.next;
            }
            Console.WriteLine("");
        }


        public static List<T> operator +(List<T> List1, List<T> List2)
        {
            List1.lastNode.next = List2.head;
            return List1;
        }

        public static List<T> operator --(List<T> List)
        {
            if (List.head == null)
                return null;
            List.head = List.head.next;
            return List;
        }

        public static bool operator ==(List<T> List1, List<T> List2)
        {
            if (ReferenceEquals(List1, List2))
                return true;
            if (List1 is null || List2 is null)
                return false;
            if (List1.count != List2.count)
                return false;
            Node<T> current1 = List1.head;
            Node<T> current2 = List2.head;
            while (current1 != null && current2 != null)
            {
                if (!EqualityComparer<T>.Default.Equals(current1.Val, current2.Val))
                {
                    return false;
                }
                current1 = current1.next;
                current2 = current2.next;
            }
            return true;
        }
        public static bool operator !=(List<T> List1, List<T> List2)
        {
            return !(List1 == List2);
        }
        public static bool operator true(List<T> list)
        {
            return list != null && list.Count > 0;
        }
        public static bool operator false(List<T> list)
        {
            return list == null && list.count == 0;
        }
        public class Developer
        {
            string fio;
            string department;

            public Developer()
            {
                fio = "unknown";
                department = "unknown";
            }
            public Developer(string Fio, string Department)
            {
                fio = Fio;
                department = Department;
            }
        }

        public static class StatisticOperation
        {
            public static List<int> sum(List<int> List1, List<int> List2)
            {
                Node<int> curent1 = List1.head;
                Node<int> curent2 = List2.head;
                List<int> result = new List<int>();
                if (List1.Count != List2.Count)
                {
                    return null;
                }
                dynamic number;
                while (curent1 != null && curent2 != null)
                {
                    result.addNode(curent1.Val + curent2.Val);
                }
                return result;
            }

            public static int substract(List<int> list)
            {
                int max = -999;
                int min = 999;
                Node<int> current = list.head;
                while (current != null)
                {
                    if (current.Val > max)
                    {
                        max = current.Val;
                    }
                    if (current.Val < min)
                    {
                        min = current.Val;
                    }
                    current = current.next;
                }
                return max - min;
            }

            public static int Count(List<T> list)
            {
                return list.count;
            }

        }
    }

}
