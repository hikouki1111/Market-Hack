private bool flightHack;
private bool speedHack;
private float speedHackH = 30f;
private float flightHackH = 30f;
private float flightHackV = 30f;

//put after 
//if (!this.isTeleporting)
//{

private moveHook() {
    if (this.speedHack)
    {
        this._speed = this.speedHackH;
    }
    if (this.flightHack)
    {
        this._speed = this.flightHackH;
        this._verticalVelocity = 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            this._verticalVelocity = this.flightHackV;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            this._verticalVelocity = -this.flightHackV;
        }
    }
}

//put after
//private void Update()
//{

private toggleUpdate() {
    if (Input.GetKeyDown(KeyCode.G))
    {
        this.flightHack = !this.flightHack;
    }
    if (Input.GetKeyDown(KeyCode.V))
    {
        this.speedHack = !this.speedHack;
    }
}