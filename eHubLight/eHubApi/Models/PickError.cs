public class PICK_ERR_SEG 
{ 
	public string WRKREF { get; set; } 
	public int CANQTY { get; set; }
	public string CANCOD { get; set; }
	public string ERROR_DESCR { get; set; } 
}

public class PICK_ERROR 
{ 
	public int MSG_ID { get; set; } 
	public double TRANDT { get; set; }
	public string WCS_ID { get; set; } = "";
	public string WH_ID { get; set; } 
	public PICK_ERR_SEG[] PICK_ERR_SEG { get; set; }  = new List<PICK_ERR_SEG>().ToArray();
}





