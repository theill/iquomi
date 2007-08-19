<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes" />
    <xsl:template match="/mainMenu">
        <xsl:apply-templates select="menu" />
    </xsl:template>
    <xsl:template match="menu">
        <xsl:if test="@visible = 'true'">
            <b>
                <xsl:if test="@link">
                    <a href="{@link}" title="{@title}">
                        <xsl:value-of select="@text" />
                    </a>
                </xsl:if>
                <xsl:if test="not(@link)">
                    <xsl:value-of select="@text" />
                </xsl:if>
            </b>
            <ul>
                <xsl:apply-templates select="menuItem|menuItemSeparator" />
            </ul>
        </xsl:if>
    </xsl:template>
    <xsl:template match="menuItem">
        <xsl:if test="@visible = 'true'">
            <li>
                <xsl:if test="not(@disabled)">
                    <a href="{@link}" title="{@title}">
                        <xsl:if test="@target">
                            <xsl:attribute name="target">
                                <xsl:value-of select="@target" />
                            </xsl:attribute>
                        </xsl:if>
                        <xsl:if test="@debug">
                            <xsl:attribute name="class">
                                <xsl:text>dbg</xsl:text>
                            </xsl:attribute>
                        </xsl:if>
                        <xsl:value-of select="@text" />
                    </a>
                </xsl:if>
                <xsl:if test="@disabled = 'true'">
                    <span class="disabled">
                        <xsl:value-of select="@text" />
                    </span>
                </xsl:if>
            </li>
        </xsl:if>
    </xsl:template>
    <xsl:template match="menuItemSeparator">
        <div class="hr">
            <hr />
        </div>
    </xsl:template>
</xsl:stylesheet>