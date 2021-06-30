<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt">
	<!-- FieldCriterionViews -->	
	<xsl:template match="view[@type='FieldCriterionView']">		
		<xsl:variable name="selected">			
			<xsl:value-of select="@SelectedField"/>		
		</xsl:variable>		
		<TR>			
			<TD width="163">				
				<SELECT id="{@Name}.SelectedField" name="{@Name}.SelectedField">					
					<xsl:for-each select="../../../../../FieldDefs/Items/FieldDef">						
						<option value="{@Name}">							
							<xsl:if test="@Name=$selected">								
								<xsl:attribute name="selected"/>							
							</xsl:if>							
							<xsl:value-of select="@Name"/>						
						</option>					
					</xsl:for-each>				
				</SELECT>				
				<FONT face="MS Sans Serif" size="1"></FONT>			
			</TD>			
			<TD>				
				<SELECT id="{@Name}.ComparisonOperator" name="{@Name}.ComparisonOperator">					
					<OPTION>						
						<xsl:if test="@ComparisonOperator='Contains'">							
							<xsl:attribute name="selected"/>						
						</xsl:if>Contains
					</OPTION>					
					<OPTION>						
						<xsl:if test="@ComparisonOperator='Does not contain'">							
							<xsl:attribute name="selected"/>						
						</xsl:if>Does not contain
					</OPTION>					
					<OPTION>						
						<xsl:if test="@ComparisonOperator='Equals'">							
							<xsl:attribute name="selected"/>						
						</xsl:if>Equals
					</OPTION>				
				</SELECT>				
				<FONT face="MS Sans Serif" size="1"></FONT>			
			</TD>			
			<TD>				
				<INPUT id="{@Name}.Terms" type="text" name="{@Name}.Terms" value="{@Terms}"/>				
				<FONT face="MS Sans Serif" size="1"></FONT>			
			</TD>			
			<TD>				
				<FONT face="MS Sans Serif" size="1"></FONT>				
				<A href="default.aspx?event=insert&amp;sender=searchrow1">					
					<FONT face="MS Sans Serif" size="1">+</FONT>				
				</A>			
			</TD>			
			<TD>				
				<FONT face="MS Sans Serif" size="1"></FONT>				
				<A href="default.aspx?event=remove&amp;sender=searchrow1">					
					<FONT face="MS Sans Serif" size="1">-</FONT>				
				</A>			
			</TD>		
		</TR>	
	</xsl:template>
</xsl:stylesheet>