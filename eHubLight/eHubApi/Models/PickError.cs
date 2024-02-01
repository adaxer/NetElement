public class PICKERRSEG 
{ 
	public string WRKREF { get; set; } 
	public int CANQTY { get; set; } 
	public string CANCOD { get; set; } 
	public string ERRORDESCR { get; set; } 
}

public class PICKERROR 
{ 
	public int MSGID { get; set; } 
	public double TRANDT { get; set; } 
	public string WCSID { get; set; } 
	public string WHID { get; set; } 
	public List<PICKERRSEG> PICKERRSEG { get; set; } 
}

