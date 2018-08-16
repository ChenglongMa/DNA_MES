using Infragistics.Win.UltraWinTree;

namespace DnaMesUiConfig.Helper
{
	//Enumerates the possiblt Drop States
	[System.Flags] public enum DropLinePositionEnum
	{
		None = 0,
		OnNode = 1,
		AboveNode = 2,
		BelowNode = 4,
		All = OnNode | AboveNode | BelowNode
	}

	public class UltraTreeDrawFilterHelper:Infragistics.Win.IUIElementDrawFilter
	{
		//This class has to implement the DrawFilter Interface
		//so it can be used as a DrawFilter by the tree

		public event System.EventHandler Invalidate;
		//public delegate void InvalidateEventHandler( object sender, EventArgs e );

		public event QueryStateAllowedForNodeEventHandler QueryStateAllowedForNode;
		public delegate void QueryStateAllowedForNodeEventHandler( object sender, QueryStateAllowedForNodeEventArgs e );

		//Used by the QueryStateAllowedForNode event
		public class QueryStateAllowedForNodeEventArgs:System.EventArgs
		{
			public UltraTreeNode Node ;
			public DropLinePositionEnum DropLinePosition;
			public DropLinePositionEnum StatesAllowed ;
		}

		public UltraTreeDrawFilterHelper()
		{
			//Initialize the properties to the defaults
			InitProperties();
		} 

		//Initialize the properties to the defaults
		private void InitProperties()
		{
			mvarDropHighLightNode = null;
			mvarDropLinePosition = DropLinePositionEnum.None;
			DropHighLightBackColor = System.Drawing.SystemColors.Highlight;
			DropHighLightForeColor = System.Drawing.SystemColors.HighlightText;
			DropLineColor = System.Drawing.SystemColors.ControlText;
			EdgeSensitivity = 0;
			DropLineWidth = 2;
		}


		//Clean up
		public void Dispose()
		{
			mvarDropHighLightNode = null;
		}

		//The DropHighLightNode is a reference to the node the
		//Mouse is currently over
		private UltraTreeNode mvarDropHighLightNode;
		public UltraTreeNode DropHightLightNode
		{
			get => mvarDropHighLightNode;
		    set
			{
				//If the Node is being set to the same value,
				// just exit
				if (mvarDropHighLightNode.Equals(value))
				{	
					return;
				}
				mvarDropHighLightNode = value;
				//The DropNode has changed.
				PositionChanged();
			}
		}

		private DropLinePositionEnum mvarDropLinePosition;
		public DropLinePositionEnum DropLinePosition
		{
			get => mvarDropLinePosition;
		    set
			{
				//If the position is the same as it was, 
				//just exit
				if (mvarDropLinePosition == value)
				{
					return;
				}
				mvarDropLinePosition = value;
				//The Drop Position has changed
				PositionChanged();
			}
		}

		//The width of the DropLine
	    public int DropLineWidth { get; set; }

	    //The BackColor of the DropHighLight node
		//This only affect the node when it is being dropped On. 
		//Not Above or Below. 
	    public System.Drawing.Color DropHighLightBackColor { get; set; }

	    //The ForeColor of the DropHighLight node
		//This only affect the node when it is being dropped On. 
		//Not Above or Below. 
	    public System.Drawing.Color  DropHighLightForeColor { get; set; }

	    //The color of the DropLine
	    public System.Drawing.Color DropLineColor { get; set; }

	    //Determines how close to the top or bottom edge of a node
		//the mouse must be to be consider dropping Above or Below
		//respectively. 
		//By default the top 1/3 of the node is Above, the bottom 1/3
		//is Below, and the middle is On. 
	    public int EdgeSensitivity { get; set; }

	    //When the DropNode or DropPosition change, we fire the
		//Invalidate event to let the program know to invalidate
		//the Tree control. 
		//This is neccessary since the DrawFilter does not have a 
		//reference to the Tree Control (although it probably could)
		private void PositionChanged()
		{
			// if nobody is listening then just return
			//
			if ( null == this.Invalidate)
				return;

			System.EventArgs e = System.EventArgs.Empty;
		
			this.Invalidate(this, e);
		}

		//Set the DropNode to Nothing and the position to None. This
		//Will clear whatever Drophighlight is in the tree
		public void ClearDropHighlight()
		{
			SetDropHighlightNode(null, DropLinePositionEnum.None);
		}

		//Call this proc every time the DragOver event of the 
		//Tree fires. 
		//Note that the point pass in MUST be in Tree coords, not
		//form coords
		public void SetDropHighlightNode(UltraTreeNode Node, System.Drawing.Point PointInTreeCoords )
		{
			//The distance from the edge of the node used to 
			//determine whether to drop Above, Below, or On a node
			int DistanceFromEdge; 
        
			//The new DropLinePosition
			DropLinePositionEnum NewDropLinePosition;
		
			DistanceFromEdge = EdgeSensitivity;
			//Check to see if DistanceFromEdge is 0
			if (DistanceFromEdge == 0)
			{
				//It is, so we use the default value - one third. 
				DistanceFromEdge = Node.Bounds.Height / 3;
			}

			//Determine which part of the node the point is in
			if (PointInTreeCoords.Y < (Node.Bounds.Top + DistanceFromEdge))
			{
				//Point is in the top of the node
				NewDropLinePosition = DropLinePositionEnum.AboveNode;
			}
			else
			{
				if (PointInTreeCoords.Y > ((Node.Bounds.Bottom - DistanceFromEdge) - 1))
				{
					//Point is in the bottom of the node
					NewDropLinePosition = DropLinePositionEnum.BelowNode;
				}
				else
				{
					//Point is in the middle of the node
					NewDropLinePosition = DropLinePositionEnum.OnNode;
				}
			}

			//Now that we have the new DropLinePosition, call the
			//real proc to get things rolling
			SetDropHighlightNode(Node, NewDropLinePosition);
		}

		private void SetDropHighlightNode(UltraTreeNode Node , DropLinePositionEnum DropLinePosition )
		{
			//Use to store whether there have been any changes in 
			//DropNode or DropLinePosition
			bool IsPositionChanged = false;

			try	
			{
				//Check to see if the nodes are equal and if 
				//the dropline position are equal
				if (mvarDropHighLightNode != null && mvarDropHighLightNode.Equals(Node) && (mvarDropLinePosition == DropLinePosition))
				{
					//They are both equal. Nothing has changed. 
					IsPositionChanged = false;
				}
				else	
				{
					//One or both have changed
					IsPositionChanged = true;
				}
			}
			catch 
			{
				//If we reach this code, it means mvarDropHighLightNode 
				//is null, so it could not be compared
				if (mvarDropHighLightNode == null)
				{
					//Check to see if Node is nothing, so we//ll know
					//if Node = mvarDropHighLightNode
					IsPositionChanged = !(Node == null);
				}
			}

			//Set both properties without calling PositionChanged
			mvarDropHighLightNode = Node;
			mvarDropLinePosition = DropLinePosition;

			//Check to see if the PositionChanged
			if (IsPositionChanged)
			{
				//Position did change.
				PositionChanged();
			}
		}

		//Only need to trap for 2 phases:
		//AfterDrawElement: for drawing the DropLine
		//BeforeDrawElement: for drawing the DropHighlight
		Infragistics.Win.DrawPhase Infragistics.Win.IUIElementDrawFilter.GetPhasesToFilter(ref Infragistics.Win.UIElementDrawParams drawParams) 
		{
			return Infragistics.Win.DrawPhase.AfterDrawElement | Infragistics.Win.DrawPhase.BeforeDrawElement;
		}

		//The actual drawing code
		bool Infragistics.Win.IUIElementDrawFilter.DrawElement(Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams)
		{
			Infragistics.Win.UIElement aUIElement;
			System.Drawing.Graphics g;
			UltraTreeNode aNode;

			//If there//s no DropHighlight node or no position
			//specified, then we don//t need to draw anything special. 
			//Just exit Function
			if ((mvarDropHighLightNode == null) || (mvarDropLinePosition == DropLinePositionEnum.None))
			{
				return false;
			}

			//Create a new QueryStateAllowedForNodeEventArgs object
			//to pass to the event
			QueryStateAllowedForNodeEventArgs eArgs = new QueryStateAllowedForNodeEventArgs();

			//Initialize the object with the correct info
			eArgs.Node = mvarDropHighLightNode;
			eArgs.DropLinePosition = this.mvarDropLinePosition;

			//Default to all states allowed. 
			eArgs.StatesAllowed = DropLinePositionEnum.All;

			//Raise the event
			this.QueryStateAllowedForNode(this, eArgs);

			//Check to see if the user allowed the current state
			//for this node. If not, exit function
			if ((eArgs.StatesAllowed & mvarDropLinePosition) != mvarDropLinePosition)
			{
				return false;
			}

			//Get the element being drawn
			aUIElement = drawParams.Element;

			//Determine which drawing phase we are in. 
			switch (drawPhase)
			{
				case Infragistics.Win.DrawPhase.BeforeDrawElement:
				{
					//We are in BeforeDrawElement, so we are only concerned with 
					//drawing the OnNode state. 
					if ((mvarDropLinePosition & DropLinePositionEnum.OnNode) == DropLinePositionEnum.OnNode)
					{
						//Check to see if we are drawing a NodeTextUIElement
						if (aUIElement.GetType() == typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement))
						{
							//Get a reference to the node that this
							//NodeTextUIElement is associated with
							aNode = (UltraTreeNode)aUIElement.GetContext(typeof(UltraTreeNode));

							//See if this is the DropHighlightNode
							if (aNode.Equals(mvarDropHighLightNode))
							{
								//Set the ForeColor and Backcolor of the node 
								//to the DropHighlight colors 
								//Note that AppearanceData only affects the
								//node for this one paint. It will not
								//change any properties of the node
								drawParams.AppearanceData.BackColor = DropHighLightBackColor;
								drawParams.AppearanceData.ForeColor = DropHighLightForeColor;
							}
						}
					}
					break;
				}
				case Infragistics.Win.DrawPhase.AfterDrawElement:
				{
					//We're in AfterDrawElement
					//So the only states we are conderned with are
					//Below and Above
					//Check to see if we are drawing the Tree Element
					if (aUIElement.GetType() == typeof(Infragistics.Win.UltraWinTree.UltraTreeUIElement))
					{
						//Declare a pen to us for drawing Droplines
						System.Drawing.Pen p = new System.Drawing.Pen(DropLineColor, DropLineWidth);

						//Get a reference to the Graphics object
						//we are drawing to. 
						g = drawParams.Graphics;

						//Get the NodeSelectableAreaUIElement for the 
						//current DropNode. We will use this for
						//positioning and sizing the DropLine
						Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement tElement ;
						tElement = (Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement)drawParams.Element.GetDescendant(typeof(Infragistics.Win.UltraWinTree.NodeSelectableAreaUIElement), mvarDropHighLightNode);

						//The left edge of the DropLine
						int LeftEdge = tElement.Rect.Left - 4;

						//We need a reference to the control to 
						//determine the right edge of the line
						UltraTree aTree; 
						aTree = (UltraTree)tElement.GetContext(typeof(UltraTree));
						int RightEdge = aTree.DisplayRectangle.Right -4;

						//Used to store the Vertical position of the 
						//DropLine
						int LineVPosition;

						if ((mvarDropLinePosition & DropLinePositionEnum.AboveNode) == DropLinePositionEnum.AboveNode)
						{
							//Draw line above node
							LineVPosition = mvarDropHighLightNode.Bounds.Top;
							g.DrawLine(p, LeftEdge, LineVPosition, RightEdge, LineVPosition);
							p.Width = 1;
							g.DrawLine(p, LeftEdge, LineVPosition - 3, LeftEdge, LineVPosition + 2);
							g.DrawLine(p, LeftEdge + 1, LineVPosition - 2, LeftEdge + 1, LineVPosition + 1);
							g.DrawLine(p, RightEdge, LineVPosition - 3, RightEdge, LineVPosition + 2);
							g.DrawLine(p, RightEdge - 1, LineVPosition - 2, RightEdge - 1, LineVPosition + 1);
						}
						if ((mvarDropLinePosition & DropLinePositionEnum.BelowNode) == DropLinePositionEnum.BelowNode)
						{
							//Draw Line below node
							LineVPosition = mvarDropHighLightNode.Bounds.Bottom;
							g.DrawLine(p, LeftEdge, LineVPosition, RightEdge, LineVPosition);
							p.Width = 1;
							g.DrawLine(p, LeftEdge, LineVPosition - 3, LeftEdge, LineVPosition + 2);
							g.DrawLine(p, LeftEdge + 1, LineVPosition - 2, LeftEdge + 1, LineVPosition + 1);
							g.DrawLine(p, RightEdge, LineVPosition - 3, RightEdge, LineVPosition + 2);
							g.DrawLine(p, RightEdge - 1, LineVPosition - 2, RightEdge - 1, LineVPosition + 1);
						}
					}
					break;
				}				
			}
			return false;
		}
	}
}