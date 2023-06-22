// See https://aka.ms/new-console-template for more information

LinkedList list = new LinkedList();
list.add(5);
list.add(2);
list.add(9);
list.add(3);
list.print();
list = list.reverse();
list.print();


public class LinkedList {
    private Node head = null;
    private int size = 0;
    public void add(int value) {
        Node newNode = new Node(value);
        if (head == null) {
            head = newNode;
            size = 1;
            return;
        }
        Node currentNode = head;
        while (currentNode.next != null) 
            currentNode = currentNode.next;
        currentNode.next = newNode;
        size++;
        return;
    }
    public void print() {
        Node currentNode = head;
        Console.Write("[ ");
        while (currentNode != null) {
            Console.Write(currentNode.value + " ");
            currentNode = currentNode.next;
        }
        Console.WriteLine("]");
        return;
    }
    public Boolean remove(int value) {
        if (head == null)
            return false;
        Node currentNode = head;
        if (head.value == value) {
            head = head.next;
            return true;
        }
        while (currentNode.next != null) {
            if (currentNode.next.value == value) {
                currentNode.next = currentNode.next.next;
                size--;
                return true;
            }
            currentNode = currentNode.next;
        }
        return false;
    }
    public Boolean removeAt(int index) {
        if (head == null)
            return false;
        if (index>=size)
            return false;
        if (index == 0) {
            head = head.next;
            size--;
        }
        Node currentNode = head;
        for (int i = 0; i<index-1; i++)
            currentNode = currentNode.next;
        currentNode.next = currentNode.next.next;
        size--;
        return true;
    }
    private Node getNode(int index) {
        Node currentNode = head;
        for (int i=0; i< index; i++) {
            currentNode = currentNode.next;
        }
        return currentNode;
    }
    private int getValue(int index) {
        Node currentNode = head;
        for (int i=0; i< index; i++) {
            currentNode = currentNode.next;
        }
        return currentNode.value;
    }
    private void swap(int index1, int index2) {
        Node node1 = this.getNode(index1);
        Node node2 = this.getNode(index2);
        int tmp = node1.value;
        node1.value = node2.value;
        node2.value = tmp;
        return;
    }
    public LinkedList reverse(){
        LinkedList newList = new LinkedList();
        newList.add(this.getValue(size-1));
        for (int i=1; i<size; i++){
            newList.add(this.getValue(size-i-1));
        }

        return newList;
    }
    private class Node {
        public int value;
        public Node next;
        public Node() {next = null;}
        public Node(int _value) {this.value = _value;}
        public Node(int _value, Node _next) {
            this.value = _value;
            this.next = _next;
            }
    }
}