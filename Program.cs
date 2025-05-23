using System.Collections;
using Microsoft.VisualBasic;

namespace ConsoleApp60
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<string> list = new();
            list.AddFirst("Daniel");
            list.AddFirst("Mari");
            list.AddFirst("Keti");
            list.AddFirst("Luka");
            list.AddFirst("Gio");

            PrintList(list.First);

            Console.WriteLine("\nAfter AddList(\"Nino\"):");
            list.AddLast("Nino");
            PrintList(list.First);

            Console.WriteLine("\nContains(\"Mari\"):" + list.Contains("Mari"));
            Console.WriteLine("Contains(\"Zura\"): " + list.Contains("Zura"));

            Console.WriteLine("\nAfter Remove(\"Mari\"):");
            list.Remove("Mari");
            PrintList(list.First);
        }

        public static void PrintList(MyNode<string> head)
        {
            MyNode<string>? current = head;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
    }

    public class MyLinkedList<T> : ICollection<T>
    {
        public MyNode<T>? First { get; private set; }
        public int Count { get; private set; }
        bool ICollection<T>.IsReadOnly => false;

        public MyNode<T> AddFirst(T value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            MyNode<T> node = new(value);
            AddFirst(node);
            return node;
        }

        public void AddFirst(MyNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node, nameof(node));

            node.Next = First;
            First = node;
            Count++;
        }

        public MyNode<T> AddLast(T value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            MyNode<T> node = new(value);
            AddLast(node);
            return node;
        }

        public void AddLast(MyNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node, nameof(node));

            if (First == null)
            {
                First = node;
            }
            else
            {
                MyNode<T>? current = First;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
            Count++;
        }

        public MyNode<T> AddAfter(MyNode<T> node, T value)
        {
            throw new NotImplementedException();
        }

        public void AddAfter(MyNode<T> node, MyNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public MyNode<T> AddBefore(MyNode<T> node, T value)
        {
            throw new NotImplementedException();
        }

        public void AddBefore(MyNode<T> node, MyNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public MyNode<T>? Find(T value)
        {
            MyNode<T>? current = First;
            while (current != null)
            {
                if (Equals(current.Value, value))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public MyNode<T>? FindLast(T value)
        {
            MyNode<T>? current = First;
            MyNode<T>? result = null;
            while (current != null)
            {
                if (Equals(current.Value, value))
                    return current;
                current = current.Next;
            }
            return result;
        }

        public void Clear()
        {
            First = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            MyNode<T>? current = First;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (First == null)
                return false;

            if (Equals(First.Value, item))
            {
                First = First.Next;
                Count--;
                return true;
            }

            MyNode<T>? current = First;
            while (current.Next != null)
            {
                if (Equals(current.Next.Value, item))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyNode<T>? current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<T>.Add(T item)
        {
            AddLast(item);
        }
    }

    public class MyNode<T>
    {
        public MyNode(T? value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public MyNode<T>? Next { get; set; }

        public override string? ToString()
        {
            return Value?.ToString();
        }
    }
}