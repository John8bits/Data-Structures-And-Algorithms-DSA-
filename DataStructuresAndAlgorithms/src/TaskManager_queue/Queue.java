package TaskManager_queue;

public class Queue {
	
	Node front;
	Node rear;
	
	int limit,count;
	
	public Queue(int limit) {
		this.limit = limit;
	}
	
	public Queue() {
		limit = 0;
	}
	
	//enqueue
	public void AddTask(String taskName, String prioLevel) {
		
		Node nwTask = new Node(taskName,prioLevel);
		
		if(front == null) {
			
			front = nwTask;
			rear = nwTask;
			
		}else {
			
			if(isFull()) {
				System.out.println("\n\nFull - Cannot add tasks");
				return;
			}
			
			//Prog DSA
			rear.setNext(nwTask);
			rear = nwTask;
		}
		
		System.out.printf("%nTask Added: %s,%s",taskName,prioLevel);
		count++;
	}
	
	//dequeue
	public void completeTask() {
		
		if(isEmpty()) {
			System.out.println("\nTask is Empty!");
			return;
		}
		//Prog DSA
		
		System.out.printf("\nTask %s enqueued successfully.",front.getItem());
		front = front.getNext();
		count--;
	}
	
	public void displayTask() {
		Node temp = front;
		
		if(isEmpty()) {
			System.out.println("Task is Empty!");
			return;
		}
		
		System.out.println("\n\nDisplay: ");
		while(temp!=null) {
			System.out.printf(" %s , %s | ",temp.getItem(),temp.getItem2());
			temp = temp.getNext();
		}
		
	}
	
	public void searchTask(String sItem) {
		System.out.println();
		System.out.println("\nSearch Task: "+sItem);
		Node temp = front;
		
		if(isEmpty()) {
			System.out.println("\nTask is empty");
			return;
		}
		boolean isFound = false;
		int i=0;
		
		while(temp!=null) {
			
			if(temp.getItem().equalsIgnoreCase(sItem)) {
				isFound = true;
				System.out.printf("Task %s , %s found at position %s %n",temp.getItem(),temp.getItem2(),i);	
			}
			temp = temp.getNext();
			i++;
		}
		
		if(!isFound) {
			System.out.printf("\n\nTask %s not found",sItem);
		}
		
		
	}
	
	public boolean isEmpty() {
		return count == 0;
	}
	
	public boolean isFull() {
		return count>=limit;
	}
	
	public int countTask() {
		System.out.println("Total Active Task: "+count);
		return count;
	}
	
	
}
