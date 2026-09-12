package doublyLinkedList;

//import dsaChall.Node;

public class DoublyLinkedList {

    private Node head;
    private Node tail;

    // Insert at end (insertItem)
    public void insertItem(int item) {
        Node newNode = new Node(item);
        if (head == null) {
            head = newNode;
            tail = newNode;
        } else {
        	
        	//1 2 3 4
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
    }

    // Insert at front
    // 1 
    /* head = nwNode;
     * tail = nwNode;
     
       else
       1 2 3 
       head.setPrev(nwNode);
       nwNode.setNext(head);
       head = nwNode;
    
    */
    
    public void insertAtFront(int item) {
        Node newNode = new Node(item);
        if (head == null) {
            head = newNode;
            tail = newNode;
        } else {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
    }

    // Insert at a specific index
    public void insertAtAnIndex(int index, int item) {
        if (index < 0) return;

        if (index == 0) {
            insertAtFront(item);
            return;
        }

        Node newNode = new Node(item);
        Node current = head;
        int count = 0;

        while (current != null && count < index - 1) {
            current = current.next;
            count++;
        }

        if (current == null || current.next == null) {
            insertItem(item); // insert at end if index is too large
        } else {
            newNode.next = current.next;
            newNode.prev = current;
            current.next.prev = newNode;
            current.next = newNode;
        }
    }

    // Delete first occurrence of item
    public void deleteItem(int item) {
        Node current = head;

        while (current != null && current.data != item) {
            current = current.next;
        }

        if (current == null) return; // not found

        if (current == head) {
            deleteFront();
        } else if (current == tail) {
            tail = current.prev;
            tail.next = null;
        } else {
            current.prev.next = current.next;
            current.next.prev = current.prev;
        }
    }

    // Delete node at index
    public void deleteItemAt(int index) {
        if (index < 0 || head == null) return;

        Node current = head;
        int count = 0;

        while (current != null && count < index) {
            current = current.next;
            count++;
        }

        if (current == null) return;

        if (current == head) {
            deleteFront();
        } else if (current == tail) {
            tail = current.prev;
            tail.next = null;
        } else {
            current.prev.next = current.next;
            current.next.prev = current.prev;
        }
    }

    // Delete the first node
    public void deleteFront() {
        if (head == null) return;

        if (head == tail) {
            head = null;
            tail = null;
        } else {
            head = head.next;
            head.prev = null;
        }
    }

    // Print list in reverse
    public void printReverse() {
        Node current = tail;
        while (current != null) {
            System.out.print(current.data + " ");
            current = current.prev;
        }
        System.out.println();
    }

    // (Optional) Print list forward
    public void printForward() {
        Node current = head;
        while (current != null) {
            System.out.print(current.data + " ");
            current = current.next;
        }
        System.out.println();
    }
}
