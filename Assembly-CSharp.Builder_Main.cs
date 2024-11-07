//replace this.canPlace = false; to this.canPlace = true;

private void Update()
{
	if (!this.initialConfiguration)
	{
		return;
	}
	if (this.recentlyMoved)
	{
		this.recentlyMoved = false;
		return;
	}
	bool value = FsmVariables.GlobalVariables.GetFsmBool("InOptions").Value;
	if (this.canvasBuilderOBJ.activeSelf && (this.cCameraController.isInCameraEvent || value))
	{
		this.DeactivateBuilder();
		return;
	}
	if (this.MainPlayer.GetButtonDown("Open Builder"))
	{
		if (!this.canvasBuilderOBJ.activeSelf)
		{
			if (this.cCameraController.isInCameraEvent || FirstPersonController.Instance.inVehicle/* || !this.pComponent.RequestGP() */)
			{
				return;
			}
			this.cCameraController.ChangeLayerMask(true);
			this.canvasBuilderOBJ.SetActive(true);
			this.SetDummy(this.currentTabIndex, this.currentElementIndex);
		}
		else
		{
			this.DeactivateBuilder();
		}
	}
	if (!this.canvasBuilderOBJ.activeSelf)
	{
		return;
	}
	if (!this.currentMovedOBJ)
	{
		if (this.MainPlayer.GetButtonDown("Menu Previous"))
		{
			this.currentElementIndex--;
			if (this.currentElementIndex < 0)
			{
				this.currentElementIndex = this.tabContainerOBJ.transform.GetChild(this.currentTabIndex).transform.Find("Container").transform.childCount - 1;
			}
			this.SetDummy(this.currentTabIndex, this.currentElementIndex);
		}
		else if (this.MainPlayer.GetButtonDown("Menu Next"))
		{
			this.currentElementIndex++;
			if (this.currentElementIndex >= this.tabContainerOBJ.transform.GetChild(this.currentTabIndex).transform.Find("Container").transform.childCount)
			{
				this.currentElementIndex = 0;
			}
			this.SetDummy(this.currentTabIndex, this.currentElementIndex);
		}
		else if (this.MainPlayer.GetButtonDown("Tab Previous"))
		{
			this.currentTabIndex--;
			if (this.currentTabIndex < 0)
			{
				this.currentTabIndex = this.tabsOrder.Length - 1;
			}
			this.currentElementIndex = 0;
			this.SetDummy(this.currentTabIndex, this.currentElementIndex);
		}
		else if (this.MainPlayer.GetButtonDown("Tab Next"))
		{
			this.currentTabIndex++;
			if (this.currentTabIndex >= this.tabsOrder.Length)
			{
				this.currentTabIndex = 0;
			}
			this.currentElementIndex = 0;
			this.SetDummy(this.currentTabIndex, this.currentElementIndex);
		}
	}
	if (this.MainPlayer.GetButtonDown("Build Snapping"))
	{
		this.snappingMode++;
		if (this.snappingMode == 2)
		{
			this.snappingMode = 3;
		}
		if (this.snappingMode >= 4)
		{
			this.snappingMode = 0;
		}
		this.snapModeTMP.text = LocalizationManager.instance.GetLocalizationString("snapping" + (this.snappingMode + 2).ToString());
		if (this.snappingMode == 0)
		{
			this.snapModeTMP.color = Color.white;
		}
		else
		{
			this.snapModeTMP.color = Color.green;
		}
	}
	if (this.currentTabIndex == 0 && this.currentElementIndex == 0)
	{
		if (this.currentMovedOBJ && this.dummyOBJ)
		{
			if (this.currentMovedOBJ.GetComponent<Data_Container>())
			{
				this.BuildableBehaviour();
			}
			else if (this.currentMovedOBJ.GetComponent<BuildableInfo>())
			{
				this.DecorationBehaviour();
			}
		}
		this.MoveBehaviour();
		return;
	}
	if (this.currentTabIndex == 0 && this.currentElementIndex == 1)
	{
		this.DeleteBehaviour();
		return;
	}
	if (this.dummyOBJ)
	{
		if (this.currentTabIndex == 0)
		{
			this.BuildableBehaviour();
			return;
		}
		this.DecorationBehaviour();
	}
}