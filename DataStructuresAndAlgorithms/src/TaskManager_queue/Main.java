package TaskManager_queue;

public class Main {

	public static void main(String[] args) {

		Queue q = new Queue(5);
		q.AddTask("Prepare project report", "high");
		q.AddTask("System defense", "high");
		q.AddTask("Rizal Reporting", "low");
		q.AddTask("OOP projects", "high");
		q.AddTask("Database quiz", "high");
		q.AddTask("DSA exam", "high");
		//q.completeTask();
		//q.completeTask();
		q.displayTask();
		q.searchTask("OOP projects");
	}

}
