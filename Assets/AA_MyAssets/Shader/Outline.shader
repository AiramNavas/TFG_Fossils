Shader "Custom/Outline"
{
	Properties	// Variables
	{
		_MainTex("Main Texture (RGB)", 2D) = "white" {} // Allow for a texture property.
		_Color("Color", Color) = (1,1,1,1) // Allow for a color property.

		_OutlineTex("Outline Texture", 2D) = "white" {}
		_OutlineColor("Outline Color", Color) = (1,1,1,1)

		_OutlineWidth("Outline Width", Range(1.0, 10.0)) = 1.1
	}

	SubShader
	{
		Tags {
		  "Queue" = "Overlay+100"
		  "IgnoreProjector" = "True"
		  "RenderType"="Transparent"
		}
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		GrabPass{}
		
		Pass
		{
			Name "OUTLINE"

			ZWrite Off

			CGPROGRAM // Allow talk between two languages: shader lab and nvidia C for graphics.

				//\====================================================================================================
				//\ Function Defines - defines the name for the vertex and fragment functions.
				//\====================================================================================================

				#pragma vertex vert // Define for the building function.
				#pragma fragment frag // Define for the color function.

				//\====================================================================================================
				//\ Includes
				//\====================================================================================================

				#include "UnityCG.cginc" // Build in shader functions.

				//\====================================================================================================
				//\ Structures - Can get data like - vertices's, normal, color, uv.
				//\====================================================================================================

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv	  : TEXCOORD0;
				};

				struct v2f
				{
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				//\====================================================================================================
				//\ Imports - Re-import property from shader lab to nvidia cg
				//\====================================================================================================

				float _OutlineWidth;
				float4 _OutlineColor;
				sampler2D _OutlineTex;

				//\====================================================================================================
				//\ Vertex Function - Build the object.
				//\====================================================================================================

				v2f vert(appdata IN)
				{
					IN.vertex.xyz *= _OutlineWidth;
					v2f OUT;

					OUT.pos = UnityObjectToClipPos(IN.vertex);
					OUT.uv = IN.uv;

					return OUT;
				}

				//\====================================================================================================
				//\ Fragment Function - Color it in
				//\====================================================================================================

				fixed4 frag(v2f IN) : SV_Target
				{
					float4 texColor = tex2D(_OutlineTex, IN.uv);
					return texColor * _OutlineColor;
				}

			ENDCG
		}

			Pass
				{
					CGPROGRAM // Allow talk between two languages: shader lab and nvidia C for graphics.

							  //\====================================================================================================
							  //\ Function Defines - defines the name for the vertex and fragment functions.
							  //\====================================================================================================

#pragma vertex vert // Define for the building function.
#pragma fragment frag // Define for the color function.

							  //\====================================================================================================
							  //\ Includes
							  //\====================================================================================================

#include "UnityCG.cginc" // Build in shader functions.

							  //\====================================================================================================
							  //\ Structures - Can get data like - vertices's, normal, color, uv.
							  //\====================================================================================================

					struct appdata
				{
					float4 vertex : POSITION;
					float2 uv	  : TEXCOORD0;
				};

				struct v2f
				{
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				//\====================================================================================================
				//\ Imports - Re-import property from shader lab to nvidia cg
				//\====================================================================================================

				float4 _Color;
				sampler2D _MainTex;

				//\====================================================================================================
				//\ Vertex Function - Build the object.
				//\====================================================================================================

				v2f vert(appdata IN)
				{
					v2f OUT;

					OUT.pos = UnityObjectToClipPos(IN.vertex);
					OUT.uv = IN.uv;

					return OUT;
				}

				//\====================================================================================================
				//\ Fragment Function - Color it in
				//\====================================================================================================

				fixed4 frag(v2f IN) : SV_Target
				{
					float4 texColor = tex2D(_MainTex, IN.uv);
					return texColor * _Color;
				}

					ENDCG
				}
	}
	FallBack "Unlit/Transparent"
}
