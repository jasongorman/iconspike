<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt"> 
	<xsl:include href="FieldCriterionView.xsl"/>
	<!-- FieldCriteriaView -->	
	<xsl:template match="view[@type='FieldCriteriaView']">	
				
			<TABLE id="fieldCriteriaView" cellSpacing="1" cellPadding="1" width="516" border="0" height="30">			
				<TR>				
					<TD width="163">					
						<FONT face="MS Sans Serif" size="1">Find documents where:</FONT>				
					</TD>				
					<TD>					
						<FONT face="MS Sans Serif" size="1"></FONT>				
					</TD>				
					<TD>					
						<A href="default.aspx?event=showallfields&amp;sender={@Name}">						
							<FONT face="MS Sans Serif" size="1">show
										all database fields</FONT>					
						</A>				
					</TD>				
					<TD>					
						<FONT face="MS Sans Serif" size="1"></FONT>				
					</TD>				
					<TD>					
						<FONT face="MS Sans Serif" size="1"></FONT>				
					</TD>			
				</TR>			
				<xsl:apply-templates select="./FieldCriterionViews/Entries/Entry/Value/view"/>		
			</TABLE>		
				
	
	</xsl:template>
</xsl:stylesheet>