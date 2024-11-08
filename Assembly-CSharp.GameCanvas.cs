private void OnGUI()
{
	Texture2D texture2D = new Texture2D(1, 1);
	texture2D.SetPixel(0, 0, Color.black);
	texture2D.Apply();
	GUIStyle guistyle = new GUIStyle();
	guistyle.fontSize = 40;
	guistyle.normal.textColor = Color.white;
	Vector2 vector = guistyle.CalcSize(new GUIContent("Market Hack 1.3"));
	GUI.DrawTexture(new Rect(20f, 200f, vector.x + 10f, 40f), texture2D);
	GUI.Label(new Rect(25f, 200f, 200f, 40f), "Market Hack 1.3", guistyle);
}

private void Update()
{
	GameData.Instance.gameFunds = 7777777f;
	GameData.Instance.gameFranchiseLevel = 7777777;
	GameData.Instance.gameFranchisePoints = 7777777;
	GameData.Instance.gameFranchiseExperience = 7777777;
	this.ShowInteractableInfo();
}

public override void OnStartClient()
{
	this.Update();
	this.UpdateUIFunds(0f, this.gameFunds);
	this.UpdateDayName(0, this.gameDay);
	this.CalculateFranchiseLevel(0, this.gameFranchiseExperience);
	this.UpdateFranchisePoints(0, this.gameFranchisePoints);
}