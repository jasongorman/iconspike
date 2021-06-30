<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt">
	<!-- DateCriteriaView -->	
	<xsl:template match="view[@type='DateCriteriaView']">		
		<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="479" border="0" height="56">			
			<TR>				
				<TD>					
					<FONT face="MS Sans Serif" size="1">That have been:</FONT>				
				</TD>				
				<TD>					
					<FONT face="MS Sans Serif" size="1">from:</FONT>				
				</TD>				
				<TD>					
					<FONT face="MS Sans Serif" size="1">to:</FONT>				
				</TD>			
			</TR>			
			<TR>				
				<TD>					
					<SELECT id="{Name}.SelectedField" name="{@Name}.SelectedField">						
						<xsl:for-each select="DateFields/Items/FieldDef">							
							<option>								
								<xsl:if test="@Name=../../../@SelectedField">									
									<xsl:attribute name="selected"/>								
								</xsl:if>								
								<xsl:value-of select="@Name"/>							
							</option>						
						</xsl:for-each>					
					</SELECT>					
					<FONT face="MS Sans Serif" size="1"></FONT>				
				</TD>				
				<TD>					
					<INPUT id="{@Name}.From" type="text" name="{@Name}.From" value="{@From}"/>					
					<FONT face="MS Sans Serif" size="1"></FONT>				
				</TD>				
				<TD>					
					<INPUT id="{@Name}.To" type="text" name="{@Name}.To" value="{@To}"/>					
					<FONT face="MS Sans Serif" size="1"></FONT>				
				</TD>			
			</TR>			
			<TR>				
				<TD>					
					<FONT face="MS Sans Serif" size="1"></FONT>				
				</TD>				
				<TD>					
					<FONT face="MS Sans Serif" size="1">e.g. 01/01/2002</FONT>				
				</TD>				
				<TD>					
					<FONT face="MS Sans Serif" size="1">e.g. 31/01/2003</FONT>				
				</TD>			
			</TR>		
		</TABLE>	
	</xsl:template>
</xsl:stylesheet>