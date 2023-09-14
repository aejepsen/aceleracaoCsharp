namespace generic_list;
// ok ok
public class GenericList<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T t)
        {
            Value = t;
            Next = null;
        }
    }

    private Node? Head;

    public GenericList()
    {
        Head = null;
    }

    public void Add(T input) 
    {
        if (Head == null)
        {
            Head = new Node(input);            
        }
        else
        {
            //Encontra onde inserir o próximo nó na lista.
            Node lastNode = Head;
            while(lastNode.Next != null)   lastNode = lastNode.Next;

            lastNode.Next = new Node(input);                        
        }
    }

    public void Print()
    {
        Node? printNode = Head;
        if (printNode == null) throw new InvalidOperationException("Não há elementos suficientes na lista");
        while(printNode.Next != null)
        {
            Console.Write(printNode.Value + " ");
            printNode = printNode.Next;
        }
        Console.WriteLine(printNode.Value);
    }

    public T Index(int index)
    {
        int i = 0;
        Node? indexNode = Head;
        if (indexNode == null) throw new InvalidOperationException("Não há elementos suficientes na lista");
        while(indexNode.Next != null)
        {
            if (i == index) return indexNode.Value;
            indexNode = indexNode.Next;
            i++;
        }
        if (i == index) return indexNode.Value;
        throw new InvalidOperationException("Não há elementos suficientes na lista");
    }

    public int Search(T element)

    {
        if (element == null) throw new InvalidOperationException("Não há elementos suficientes na lista");
        int count = 0;

        Node? currentNode = Head;
        if (currentNode == null) throw new InvalidOperationException("Não há elementos suficientes na lista");
        while (currentNode.Value.ToString() != element.ToString())
        {
            if (currentNode.Next == null) throw new InvalidOperationException("Elemento não está na lista");

            count += 1;
            currentNode = currentNode.Next;
        }
        return count;
    }
    
}