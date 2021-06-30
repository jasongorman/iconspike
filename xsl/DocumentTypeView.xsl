<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt">	

	<!-- DocumentTypeView -->	
	<xsl:template match="view[@type='DocumentTypeView']">	
	
		<TR>			
			<TD>				
				<FONT face="MS Sans Serif" size="1">					
					<input name="{@Name}.Selected" type="checkbox" id="{@Name}.Selected">						
						<xsl:if test="@Selected='True'">							
							<xsl:attribute name="checked"/>						
						</xsl:if>					
					</input>				
				</FONT>			
			</TD>			
			<TD>				
				<FONT face="MS Sans Serif" color="#000099" size="1">					
					<xsl:value-of select="@Caption"/>				
				</FONT>			
			</TD>		
		</TR>	
		
	</xsl:template>
</xsl:stylesheet>