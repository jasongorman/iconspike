<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt"> 
	<xsl:include href="DocumentTypeView.xsl"/> 	

	<!-- DocumentTypesView -->	
	<xsl:template match="view[@type='DocumentTypesView']">		
		<form method="post"	action="default.aspx?event=update&amp;sender={@Name}">			
			<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="342" border="0" height="161">				
				<TR>					
					<TD colspan="2">						
						<FONT face="MS Sans Serif" size="1">Look for these types of document:</FONT>					
					</TD>				
				</TR>				
				<TR>					
					<TD vAlign="top">						
						<P>							
							<TABLE id="Table6" height="93" cellSpacing="1" cellPadding="1" width="161" border="0">								
								<xsl:apply-templates select="DocumentTypeViews/Entries/Entry/Value">									
									<xsl:with-param name="isChild" select="'true'"/>								
								</xsl:apply-templates>							
							</TABLE>						
						</P>					
					</TD>				
				</TR>			
			</TABLE>			
			<input type="submit" value="submit"/>		
		</form>	
	</xsl:template>
</xsl:stylesheet>