private bool flightHack;
private bool speedHack;
private bool spammerHack;
private bool hopHack;
private bool airJumpHack;
private float speedHackH = 30f;
private float flightHackH = 30f;
private float flightHackV = 30f;

private void JumpAndGravity()
{
    //replace this.Grounded to this.Grounded || airJumpHack
    if (this.Grounded || airJumpHack)
    {
        this._fallTimeoutDelta = this.FallTimeout;
        if (this._verticalVelocity < 0f)
        {
            this._verticalVelocity = -2f;
        }
        if (this.MainPlayer.GetButton("Jump") && this._jumpTimeoutDelta <= 0f && this.allowPlayerInput)
        {
            this._verticalVelocity = Mathf.Sqrt(this.JumpHeight * -2f * this.Gravity);
        }
        if (this._jumpTimeoutDelta >= 0f)
        {
            this._jumpTimeoutDelta -= Time.deltaTime;
        }
    }
    else
    {
        this._jumpTimeoutDelta = this.JumpTimeout;
        if (this._fallTimeoutDelta >= 0f)
        {
            this._fallTimeoutDelta -= Time.deltaTime;
        }
    }
    if (this._verticalVelocity < this._terminalVelocity)
    {
        this._verticalVelocity += this.Gravity * Time.deltaTime;
    }
}

private void Hop()
{
    if (this.flightHack)
    {
        return;
    }

    this._speed = this.speedHack ? this.speedHackH : this.SprintSpeed;
    if (this.Grounded)
    {
        this._jumpTimeoutDelta = 0f;
        this._fallTimeoutDelta = this.FallTimeout;
        if (this._verticalVelocity < 0f)
        {
            this._verticalVelocity = -2f;
        }
        if (this._jumpTimeoutDelta <= 0f && this.allowPlayerInput)
        {
            this._verticalVelocity = Mathf.Sqrt(this.JumpHeight * -2f * this.Gravity);
        }
        if (this._jumpTimeoutDelta >= 0f)
        {
            this._jumpTimeoutDelta -= Time.deltaTime;
        }
    }
    else
    {
        this._jumpTimeoutDelta = this.JumpTimeout;
        if (this._fallTimeoutDelta >= 0f)
        {
            this._fallTimeoutDelta -= Time.deltaTime;
        }
    }
    if (this._verticalVelocity < this._terminalVelocity)
    {
        this._verticalVelocity += this.Gravity * Time.deltaTime;
    }
}

//put after 
//if (!this.isTeleporting)
//{

private void moveHook() {
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
    if (this.hopHack) {
        Hop();
    }
}

//put after
//private void Update()
//{

private void updateHook() {
    if (Input.GetKeyDown(KeyCode.G))
    {
        this.flightHack = !this.flightHack;
    }
    if (Input.GetKeyDown(KeyCode.V))
    {
        this.speedHack = !this.speedHack;
    }
    if (Input.GetKeyDown(KeyCode.B)) {
        this.hopHack = !this.hopHack;
    }
    if (Input.GetKeyDown(KeyCode.N)) {
        this.airJumpHack = !this.airJumpHack;
    }
}