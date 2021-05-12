using System;

namespace DataStructures
{
    public class DoublyLinkedList
    {
        public int Count { get; private set; }

        public ListElement First { get; private set; }

        public ListElement Last { get; private set; }

        public ListElement AddFirst(string value)
        {
            var elementToAdd = new ListElement(value, this);

            if (First != null)
            {
                elementToAdd.NextElement = First;
                First.PreviousElement = elementToAdd;                
            }
            First = elementToAdd;

            if (Last == null)
            {
                Last = elementToAdd;
            }
            Count++;

            return elementToAdd;
        }

        public ListElement AddLast(string value)
        {
            var elementToAdd = new ListElement(value, this);

            if (Last != null)
            {
                elementToAdd.PreviousElement = Last;
                Last.NextElement = elementToAdd;
            }
            Last = elementToAdd;

            if (First == null)
            {
                First = elementToAdd;
            }
            Count++;

            return elementToAdd;
        }

        public string GetAndRemoveFirst()
        {
            if (First != null)
            {
                string value = First.Value;
                if (First.NextElement == null)
                {
                    DetachElement(First);
                    First = null;
                    Last = null;
                }
                else
                {
                    var removedEl = First;
                    First = First.NextElement;
                    First.PreviousElement = null;
                    DetachElement(removedEl);
                }
                Count--;
                return value;
            }
            else
            {
                return null;
            }
        }

        public string GetAndRemoveLast()
        {
            if (Last != null)
            {
                string value = Last.Value;
                if (Last.PreviousElement == null)
                {
                    DetachElement(Last);
                    First = null;
                    Last = null;
                }
                else
                {
                    var removedEl = Last;
                    Last = Last.PreviousElement;
                    Last.NextElement = null;
                    DetachElement(removedEl);
                }

                Count--;
                return value;
            }
            else
            {
                return null;
            }
        }

        public void InsertAfter(ListElement element, string value)
        {
            ValidateElement(element);

            var elementToInsert = new ListElement(value, this);

            if (Last == element)
            {
                elementToInsert.PreviousElement = element;
                elementToInsert.NextElement = null;
                element.NextElement = elementToInsert;
                Last = elementToInsert;
            }
            else
            {
                var nextElement = element.NextElement;
                elementToInsert.NextElement = nextElement;
                elementToInsert.PreviousElement = element;
                nextElement.PreviousElement = elementToInsert;
                element.NextElement = elementToInsert;
            }

            Count++;
        }

        public void RemoveElement(ListElement element)
        {
            ValidateElement(element);

            if (First == element)
            {
                GetAndRemoveFirst();
            }
            else if (Last == element)
            {
                GetAndRemoveLast();
            }
            else
            {
                var nextElement = element.NextElement;
                var prevElement = element.PreviousElement;
                nextElement.PreviousElement = prevElement;
                prevElement.NextElement = nextElement;
                DetachElement(element);
                Count--;
            }
        }

        public ListElement this[int index]
        {
            get
            {
                if (index == Count-1)
                {
                    return Last;
                }
                if (index < Count)
                {
                    var el = First;
                    if (First != null)
                    {
                        if (index == 0)
                            return el;
                        while (el.NextElement != null)
                        {
                            if (index == 0)
                                return el;
                            el = el.NextElement;
                            index--;
                        }
                    }
                }
                Console.WriteLine("Element not found");
                return null;
            }
        }

        private void ValidateElement(ListElement element)
        {
            if (element.OwnerList != this)
                throw new ElementNotIsListException();
        }

        private void DetachElement(ListElement element)
        {
            element.OwnerList = null;
            element.PreviousElement = null;
            element.NextElement = null;
        }

        public void DisplayList()
        {
            Console.WriteLine("List");
            var el = First;
            if (First != null)
            {
                Console.WriteLine(el.Value);
                while (el.NextElement != null)
                {
                    el = el.NextElement;
                    Console.WriteLine(el.Value);
                }
            }
        }
    }

    public class ListElement
    {
        internal ListElement(string value, DoublyLinkedList ownerList)
        {
            Value = value;
            OwnerList = ownerList;
        }

        internal DoublyLinkedList OwnerList { get; set; }

        public ListElement PreviousElement { get; internal set; }

        public ListElement NextElement { get; internal set; }

        public string Value { get; private set; }
    }

    public class LinkedListException : Exception { }

    public class ListIsEmptyException : LinkedListException { }

    public class ElementNotIsListException : LinkedListException { }
}