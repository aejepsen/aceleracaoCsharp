namespace calendar_events;
#pragma warning disable CS8602

public class EventList
{
    private class Node
    {
        public Event Value;
        public Node? Next;

        public Node(Event t)
        {
            Value = t;
            Next = null;
        }
    }

    private Node? Head;

    public void GenericList()
    {
        Head = null;
    }

    public void Add(Event input) 
    {
        if (Head == null)
        {
            Head = new Node(input);            
        }
        else
        {
            //Encontra onde inserir o próximo nó na lista.
            Node? lastNode = Head;
            while(lastNode.Next != null)   lastNode = lastNode.Next;

            lastNode.Next = new Node(input);                        
        }
    }

    public void Print(string format)
    {
        Node? printNode = Head;
        while(printNode.Next != null)
        {
            
        }
        
    }

    public Event Index(int index)
    {
        Node? searchNode = Head;
        for(int i = 0; i < index; i++)
        {
            if(searchNode.Next != null)
            {
                searchNode = searchNode.Next;
                continue;
            }
            else
            {
                throw new InvalidOperationException("Não há elementos suficientes na lista");
            }
        }
        return searchNode.Value;
    }

    public int SearchByTitle(string title)
    {
        Node? searchNode = Head;
        int index = 0;
        if(searchNode == null)
        {
            throw new InvalidOperationException("Não há elementos suficientes na lista");
        }
        while(searchNode.Next != null)
        {
            searchNode = searchNode.Next;
            index++;
        }
        if(searchNode.Value.Title == title)
        {
            return index;
        }
        else
        {
            return -1;
        }

    }

    public int SearchByDate(string dateSearch)
    {
        Node? searchNode = Head;
        int index = 0;

        if(searchNode == null)
        {
            throw new InvalidOperationException("Não há elementos suficientes na lista");
        }

        while(searchNode.Next != null)
        {
                searchNode = searchNode.Next;
                index++;

        }
        if(searchNode.Value.EventDate == DateTime.Parse(dateSearch))
        {
            return index;
        }
        else
        {
            return -1;
        }
    }
    
}