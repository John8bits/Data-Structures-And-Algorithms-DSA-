package singlyLinkedList;

public class Main {

	public static void main(String[] args) {

		singleLinkedList sll = new singleLinkedList();
		sll.insertItem(1);
		sll.insertItem(2);
		sll.insertItem(3);
		sll.insertItem(4);
		sll.insertItem(5);
		sll.insertHead(0);
		sll.insertItem(6);
		sll.insertItem(7);
		sll.insertTail(20);
		sll.insertTail(21);
		sll.insertAtIndex(2, 32);
		sll.deleteHead();
		sll.deleteHead();
		sll.deleteTail();
		sll.display();
	}

}
