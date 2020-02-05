<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewFlexMLS_List.ascx.cs" Inherits="GIBS.Modules.FlexMLS_List.ViewFlexMLS_List" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>




<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FlexMLS/css/Style.css" />

<!-- fotorama.css & fotorama.js. -->
<link  href="https://cdnjs.cloudflare.com/ajax/libs/fotorama/4.6.4/fotorama.css" rel="stylesheet" /> <!-- 3 KB -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/fotorama/4.6.4/fotorama.js" type="text/javascript"></script> <!-- 16 KB -->

<!-- 2. Add images to <div class="fotorama"></div>. -->


<asp:Label ID="lblDebug" runat="server" Text=""></asp:Label>
<div class="searchcriteria" id="divSearchCriteria" runat="server"><asp:Label ID="lblSearchCriteria" runat="server" Text="" Visible="True"></asp:Label></div>


<asp:Label ID="lblSearchSummary" runat="server" Text="0 Records Found"></asp:Label>

<div class="container-fluid"> 
  <asp:datalist id="lstSearchResults" datakeyfield="ListingNumber" runat="server" cellpadding="4" Width="100%" OnItemDataBound="lstSearchResults_ItemDataBound" >
  <itemtemplate>

  <div class="row">
	
    <div class="col-sm-4">
           <div class="fotorama" data-fit="cover" data-width="100%" data-ratio="800/600">           
<asp:HyperLink ID="HyperLinkImage" runat="server"><asp:Image ID="imgListingImage" runat="server" AlternateText="Cape Cod MLS" /></asp:HyperLink>
</div>  

	</div>

	<div class="col-sm-8">
    <!--- ROW 1 --->
        <div class="row">

	        <div class="col-sm-8">
		        <asp:HyperLink ID="hyperlinkListingAddress" Text="Listing Address" CssClass="ListingAddress" runat="server" />
	        </div>


	
	        <div class="col-sm-4 text-right">
                <asp:Label ID="lblListingPrice" runat="server" CssClass="ListingPrice" />
                <asp:Image ID="imgPriceChange" runat="server" ImageUrl="~/DesktopModules/GIBS/FlexMLS/Images/arrow_down.png" />
	        </div>

        </div>
         <div class="row">
	        <div class="col-sm-4">
                <asp:Label ID="lblYearBuilt" runat="server" CssClass="ListingDetails" />
	        </div>
             <div class="col-sm-4"><asp:Label ID="lblMLNumber" runat="server" CssClass="listingstatus"/>
                 </div>
             <div class="col-sm-4"><asp:Label ID="lblListingStatus" runat="server" Text="" CssClass="listingstatus" />
                 </div>
        </div>
    <!--- ROW 2 --->
        <div class="row">

	        <div class="col-sm-6">
		        <asp:Label ID="lblBedsBaths" runat="server" Text="" />
	        </div>

	        <div class="col-sm-3">
                <asp:Label ID="lblLotSquareFootage" runat="server" CssClass="ListingDetails" />
	        </div>
	
	        <div class="col-sm-3">
            <asp:Label ID="lblLivingSpace" runat="server" CssClass="ListingDetails" />
	        </div>

        </div>
        <p><asp:PlaceHolder ID="PlaceHolder_RegisterUserContent" runat="server"></asp:PlaceHolder></p>
        <p class="ListingLinks">

        <asp:HyperLink ID="HyperLinkVirtualTourLink" runat="server" CssClass="ActionLinks" Target="_blank"><asp:Image ID="ImageVirtualTour1" runat="server" ImageUrl="~/DesktopModules/GIBS/FlexMLS/Images/VirtualTour.png" AlternateText="Virtual Tour" /></asp:HyperLink>

        <asp:HyperLink ID="hyperlinkListingDetail" Text="Listing Details" NavigateUrl="" runat="server" CssClass="btn btn-xs btn-default" />
          <asp:HyperLink ID="HyperLinkShowing" runat="server" CssClass="btn btn-xs btn-default" Text="Schedule Showing" /> 
          <asp:HyperLink ID="HyperLinkInquiry" runat="server" CssClass="btn btn-xs btn-default" Text="Inquiry" />
          <asp:LinkButton ID="linkButtonFavoritesAddListing" runat="server" CommandArgument='<%# Eval("ListingNumber") %>' 
         onclick="linkButtonFavoritesAddListing_Click" CssClass="btn btn-xs btn-default" Text="Add to Favorites" /> 
          <asp:HyperLink ID="HyperLinkTellAFriend" runat="server" CssClass="btn btn-xs btn-default" Text="E-Mail A Friend" /> 
         </p>


    

</div>
       <div class="row">
           <div class="col-sm-12">
        <!--- DETAILS --->

        

   <div class="MarketingRemarks"><asp:Label ID="lblMarketingRemarks" runat="server" />
                <asp:Image ID="imgBRLogo" runat="server" ImageAlign="Right" ImageUrl="~/DesktopModules/GIBS/FlexMLS/Images/BrokerReciprocity.gif" AlternateText="Broker Reciprocity (BR) of the Cape Cod & Islands MLS" Width="107px" Height="25px" /></div>
        
     
            

        

        


               </div>
	</div>


	


</div>
<hr />
<br />&nbsp;

  </itemtemplate> 
</asp:datalist>

</div>

<dnn:PagingControl id="PagingControl1" runat="server" Visible="False" BackColor="#FFFFFF" BorderColor="#000000" ></dnn:PagingControl>

 
<p class="disclaimer"><asp:Image ID="Image1" runat="server" ImageUrl="~/DesktopModules/GIBS/FlexMLS/Images/BrokerReciprocity.gif" AlternateText="Broker Reciprocity (BR) of the Cape Cod & Islands MLS" ImageAlign="Left" Width="107px" Height="25px" />

The data relating to real estate for sale on this site comes from the Broker Reciprocity (BR) of the Cape Cod &amp; Islands 
Multiple Listing Service, Inc. Summary or thumbnail real estate listings held by brokerage firms other than <b><%=  this.PortalSettings.PortalName.ToString() %></b> 
are marked with the BR Logo and detailed information about them includes the name of the listing broker.  Neither the 
listing broker nor <b><%=  this.PortalSettings.PortalName.ToString() %></b> shall be responsible for any typographical errors, misinformation, or misprints and 
shall be held totally harmless.
</p>   