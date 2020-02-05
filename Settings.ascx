<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.FlexMLS_List.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>


<div class="dnnForm" id="form-settings">


    <fieldset>

<dnn:sectionhead id="sectGeneralSettings" cssclass="Head" runat="server" text="General Settings" section="GeneralSection"
	includerule="False" isexpanded="True"></dnn:sectionhead>

<div id="GeneralSection" runat="server">   


             
                    
                    		
<div class="dnnFormItem">					
<dnn:label id="lblFavoritesModuleID" runat="server" suffix=":" controlname="drpModuleID" ResourceKey="lblFavoritesModuleID" />
			<asp:dropdownlist id="drpModuleID" Runat="server" Width="325" datavaluefield="ModuleID" datatextfield="ModuleTitle"
				CssClass="NormalTextBox" AutoPostBack="True"></asp:dropdownlist></div>	

                <div class="dnnFormItem">
    <dnn:label id="lblMLSImagesUrl" runat="server" controlname="txtMLSImagesUrl" suffix=":" />
            <asp:textbox id="txtMLSImagesUrl" runat="server" Text="https://gibs.com/Images/" />		
        </div>

       <div class="dnnFormItem">
            <dnn:label id="lblShowCriteria" runat="server" suffix=":" controlname="cbxShowCriteria" ResourceKey="lblShowCriteria" />
           <asp:CheckBox ID="cbxShowCriteria" runat="server" />
            
        </div>

       <div class="dnnFormItem">
            <dnn:label id="lblViewListing" runat="server" suffix=":" controlname="ddlViewListing" ResourceKey="lblViewListing" />
           <asp:dropdownlist id="ddlViewListing" Runat="server"></asp:dropdownlist>
            
        </div>

        <div class="dnnFormItem">
            <dnn:label id="lblListingNumbers" runat="server" suffix=":" controlname="txtListingNumbers" ResourceKey="lblListingNumbers" />
           <asp:TextBox id="txtListingNumbers" Runat="server" /></div>

	     <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblNumberOfRecords" ControlName="txtNumberOfRecords" ResourceKey="lblNumberOfRecords" Suffix=":" />
            <asp:Textbox ID="txtNumberOfRecords" runat="server" Text="15" />
        </div>	      
        
 	     <div class="dnnFormItem">
            <dnn:label id="lblShowPaging" runat="server" controlname="cbxShowPaging" suffix=":" ResourceKey="lblShowPaging" />
            <asp:CheckBox ID="cbxShowPaging" runat="server" />

        </div>	  
        
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblThumbSize" ControlName="txtThumbSize" ResourceKey="lblThumbSize" Suffix=":" />
            <asp:Textbox ID="txtThumbSize" runat="server" Width="80px" Text="260" />
        </div>	

</div>  


<dnn:sectionhead id="sectMainSettings" cssclass="Head" runat="server" text="Search Settings" section="MainSection"
	includerule="False" isexpanded="False"></dnn:sectionhead>

<div id="MainSection" runat="server">


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblPropertyType" ControlName="ddlPropertyType" ResourceKey="lblPropertyType" Suffix=":" />
            <asp:DropDownList ID="ddlPropertyType" runat="server">
                <asp:ListItem Value="">Please Select</asp:ListItem>
                <asp:ListItem Value="RESI">Single Family</asp:ListItem>
                <asp:ListItem Value="MULT">Multi-Family</asp:ListItem>
                <asp:ListItem Value="COND">Condo</asp:ListItem>
                <asp:ListItem Value="COMM">Commercial</asp:ListItem>
                <asp:ListItem Value="HOTL">Hotel-Motel</asp:ListItem>
                <asp:ListItem Value="LOTL">Land</asp:ListItem>
            </asp:DropDownList>
            
        </div>


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblTownVillage" ControlName="ddl_Town" ResourceKey="lblTownVillage" Suffix=":" />
<asp:DropDownList ID="ddl_Town" runat="server" Width="20%" AutoPostBack="True" onselectedindexchanged="ddl_Town_SelectedIndexChanged"  /> <asp:DropDownList ID="ddl_Village" runat="server" Width="20%" EnableViewState="true" CausesValidation="false" /> 

</div> 
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblBedRooms" ControlName="ddlBedRooms" ResourceKey="lblBedRooms" Suffix=":" />
            <asp:DropDownList ID="ddlBedRooms" runat="server">
                <asp:ListItem Value="0">Please Select</asp:ListItem>
				<asp:ListItem Value="1">1 or More Bedrooms</asp:ListItem>
				<asp:ListItem Value="2">2 or More Bedrooms</asp:ListItem>
				<asp:ListItem Value="3">3 or More Bedrooms</asp:ListItem>
				<asp:ListItem Value="4">4 or More Bedrooms</asp:ListItem>
				<asp:ListItem Value="5">5 or More Bedrooms</asp:ListItem>
				<asp:ListItem Value="6">6 or More Bedrooms</asp:ListItem>

            </asp:DropDownList>
            
        </div>

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblBathRooms" ControlName="ddlBathRooms" ResourceKey="lblBathRooms" Suffix=":" />
            <asp:DropDownList ID="ddlBathRooms" runat="server">
                <asp:ListItem Value="0">Please Select</asp:ListItem>
				<asp:ListItem Value="1">1 or More Bathrooms</asp:ListItem>
				<asp:ListItem Value="2">2 or More Bathrooms</asp:ListItem>
				<asp:ListItem Value="3">3 or More Bathrooms</asp:ListItem>
				<asp:ListItem Value="4">4 or More Bathrooms</asp:ListItem>
				<asp:ListItem Value="5">5 or More Bathrooms</asp:ListItem>
				<asp:ListItem Value="6">6 or More Bathrooms</asp:ListItem>
            </asp:DropDownList>
            
        </div>	


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblPriceRange" ControlName="ddlPriceLow" ResourceKey="lblPriceRange" Suffix=":" />
            <asp:DropDownList ID="ddlPriceLow" runat="server" Width="20%">
                <asp:ListItem Value="0">Min Price</asp:ListItem>
				<asp:ListItem Value="100000">$100,000</asp:ListItem>
				<asp:ListItem Value="150000">$150,000</asp:ListItem>
				<asp:ListItem Value="200000">$200,000</asp:ListItem>
				<asp:ListItem Value="250000">$250,000</asp:ListItem>
				<asp:ListItem Value="300000">$300,000</asp:ListItem>
				<asp:ListItem Value="350000">$350,000</asp:ListItem>
				<asp:ListItem Value="400000">$400,000</asp:ListItem>
				<asp:ListItem Value="450000">$450,000</asp:ListItem>
				<asp:ListItem Value="500000">$500,000</asp:ListItem>
				<asp:ListItem Value="550000">$550,000</asp:ListItem>
				<asp:ListItem Value="600000">$600,000</asp:ListItem>
				<asp:ListItem Value="650000">$650,000</asp:ListItem>
				<asp:ListItem Value="700000">$700,000</asp:ListItem>
				<asp:ListItem Value="750000">$750,000</asp:ListItem>
				<asp:ListItem Value="800000">$800,000</asp:ListItem>
				<asp:ListItem Value="850000">$850,000</asp:ListItem>
				<asp:ListItem Value="900000">$900,000</asp:ListItem>
				<asp:ListItem Value="950000">$950,000</asp:ListItem>
				<asp:ListItem Value="1000000">$1,000,000</asp:ListItem>
				<asp:ListItem Value="1250000">$1,250,000</asp:ListItem>
				<asp:ListItem Value="1500000">$1,500,000</asp:ListItem>
                <asp:ListItem Value="1750000">$1,750,000</asp:ListItem>
				<asp:ListItem Value="2000000">$2,000,000</asp:ListItem>
                <asp:ListItem Value="2500000">$2,500,000</asp:ListItem>
                <asp:ListItem Value="3000000">$3,000,000</asp:ListItem>

            </asp:DropDownList>
			
			            <asp:DropDownList ID="ddlPriceHigh" runat="server" Width="20%">
                <asp:ListItem Value="50000000">Max Price</asp:ListItem>
				<asp:ListItem Value="150000">$150,000</asp:ListItem>
				<asp:ListItem Value="200000">$200,000</asp:ListItem>
				<asp:ListItem Value="250000">$250,000</asp:ListItem>
				<asp:ListItem Value="300000">$300,000</asp:ListItem>
				<asp:ListItem Value="350000">$350,000</asp:ListItem>
				<asp:ListItem Value="400000">$400,000</asp:ListItem>
				<asp:ListItem Value="450000">$450,000</asp:ListItem>
				<asp:ListItem Value="500000">$500,000</asp:ListItem>
				<asp:ListItem Value="550000">$550,000</asp:ListItem>
				<asp:ListItem Value="600000">$600,000</asp:ListItem>
				<asp:ListItem Value="650000">$650,000</asp:ListItem>
				<asp:ListItem Value="700000">$700,000</asp:ListItem>
				<asp:ListItem Value="750000">$750,000</asp:ListItem>
				<asp:ListItem Value="800000">$800,000</asp:ListItem>
				<asp:ListItem Value="850000">$850,000</asp:ListItem>
				<asp:ListItem Value="900000">$900,000</asp:ListItem>
				<asp:ListItem Value="950000">$950,000</asp:ListItem>
				<asp:ListItem Value="1000000">$1,000,000</asp:ListItem>
				<asp:ListItem Value="1250000">$1,250,000</asp:ListItem>
				<asp:ListItem Value="1500000">$1,500,000</asp:ListItem>
				<asp:ListItem Value="2000000">$2,000,000</asp:ListItem>
                <asp:ListItem Value="3000000">$3,000,000</asp:ListItem>
                <asp:ListItem Value="4000000">$4,000,000</asp:ListItem>
                <asp:ListItem Value="5000000">$5,000,000</asp:ListItem>
                <asp:ListItem Value="10000000">$10,000,000</asp:ListItem>
                <asp:ListItem Value="25000000">$25,000,000</asp:ListItem>
            </asp:DropDownList>
            
        </div>	

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblWaterFront" ControlName="cbxWaterFront" ResourceKey="lblWaterFront" Suffix=":" />
           <asp:CheckBox ID="cbxWaterFront" runat="server" />
            
        </div>

		        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblWaterView" ControlName="cbxWaterView" ResourceKey="lblWaterView" Suffix=":" />
            <asp:CheckBox ID="cbxWaterView" runat="server" />
            
        </div>

        <div class="dnnFormItem">
            <dnn:label id="lblYearBuilt" runat="server" suffix=":" controlname="txtYearBuilt" ResourceKey="lblYearBuilt" />
           <asp:TextBox id="txtYearBuilt" Runat="server" /></div>	

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblComplex" ControlName="ddlComplex" ResourceKey="lblComplex" Suffix=":" />
            <asp:DropDownList ID="ddlComplex" runat="server">
                <asp:ListItem Value="">Please Select</asp:ListItem>

            </asp:DropDownList>
            
        </div>	
                <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblDaysOnMarket" ControlName="ddlDOM" ResourceKey="lblDaysOnMarket" Suffix=":" />
            <asp:DropDownList ID="ddlDOM" runat="server">
                <asp:ListItem Value="">Show All</asp:ListItem>
                <asp:ListItem Value="1">New Today</asp:ListItem>
                <asp:ListItem Value="3">3 days on market or less</asp:ListItem>
                <asp:ListItem Value="7">7 days on market or less</asp:ListItem>
                <asp:ListItem Value="14">14 days on market or less</asp:ListItem>
                <asp:ListItem Value="21">21 days on market or less</asp:ListItem>
                <asp:ListItem Value="30">30 days on market or less</asp:ListItem>
            </asp:DropDownList>
            
        </div>


		  <div class="dnnFormItem">
            <dnn:label id="lblListingOfficeMLSID" runat="server" suffix=":" controlname="txtListingOfficeMLSID" ResourceKey="lblListingOfficeMLSID" />
          
           <asp:DropDownList ID="ddlOfficeID" runat="server" />
           </div>
        



 </div>
        			


  




    </fieldset>

</div>