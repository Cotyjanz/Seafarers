//http://wiki.unity3d.com/index.php/DepthMask
// Neil Carter (NCarter) and Daniel Brauer (Danielbrauer) 

Shader "Masked/Mask" {
 
    SubShader {
        // Render the mask after regular geometry, but before masked geometry and
        // transparent things.
 
        Tags {"Queue" = "Geometry+10" }
 
        //Writing ColorMask 0 turns off rendering to all color channels 
        ColorMask 0

        ZWrite On
 
        //The Pass block causes the geometry of a GameObject to be rendered once
        //Do nothing in this pass
        Pass {}
    }
}