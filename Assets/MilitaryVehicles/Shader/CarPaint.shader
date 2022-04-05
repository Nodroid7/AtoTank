// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "CarPaint"
{
	Properties 
	{
_Diffuse("_Diffuse", 2D) = "white" {}
_DiffuseColor("_DiffuseColor", Color) = (1,1,1,1)
_DiffuseMultiply("_DiffuseMultiply", Range(0,3) ) = 1
_DiffuseAdd("_DiffuseAdd", Range(0,1) ) = 0
_DiffPosFresnel("_DiffPosFresnel", Range(0,5) ) = 0
_DiffNegFresnel("_DiffNegFresnel", Range(0,5) ) = 0
_Normal("_Normal", 2D) = "bump" {}
_NormalMultiply("_NormalMultiply", Range(0,5) ) = 1
_Cube("_Cube", Cube) = "white" {}
_RefMultiply("_RefMultiply", Range(0,1) ) = 0
_RefFresnel("_RefFresnel", Range(0,3) ) = 0
_SpecularMap("_SpecularMap", 2D) = "gray" {}
_SpecularFalloff("_SpecularFalloff", Range(0,1) ) = 0.293
_SpecularMultiply("_SpecularMultiply", Range(0,2) ) = 1.201

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Blend SrcAlpha OneMinusSrcAlpha
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  fullforwardshadows noambient vertex:vert
#pragma target 3.0


sampler2D _Diffuse;
float4 _DiffuseColor;
float _DiffuseMultiply;
float _DiffuseAdd;
float _DiffPosFresnel;
float _DiffNegFresnel;
sampler2D _Normal;
float _NormalMultiply;
samplerCUBE _Cube;
float _RefMultiply;
float _RefFresnel;
sampler2D _SpecularMap;
float _SpecularFalloff;
float _SpecularMultiply;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_Diffuse;
float3 viewDir;
float2 uv_Normal;
float3 simpleWorldRefl;
float2 uv_SpecularMap;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);

o.simpleWorldRefl = -reflect( normalize(WorldSpaceViewDir(v.vertex)), normalize(mul((float3x3)unity_ObjectToWorld, SCALED_NORMAL)));

			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D0=tex2D(_Diffuse,(IN.uv_Diffuse.xyxy).xy);
float4 Multiply3=Tex2D0 * _DiffuseMultiply.xxxx;
float4 Fresnel2_1_NoInput = float4(0,0,1,1);
float4 Fresnel2=(1.0 - dot( normalize( float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 ).xyz), normalize( Fresnel2_1_NoInput.xyz ) )).xxxx;
float4 Invert0= float4(1.0, 1.0, 1.0, 1.0) - Fresnel2;
float4 Pow2=pow(Invert0,_DiffNegFresnel.xxxx);
float4 Multiply5=Multiply3 * Pow2;
float4 Fresnel3_1_NoInput = float4(0,0,1,1);
float4 Fresnel3=(1.0 - dot( normalize( float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 ).xyz), normalize( Fresnel3_1_NoInput.xyz ) )).xxxx;
float4 Pow3=pow(Fresnel3,_DiffPosFresnel.xxxx);
float4 Multiply6=Multiply5 * Pow3;
float4 Add0=Multiply6 + _DiffuseAdd.xxxx;
float4 Multiply4=Add0 * _DiffuseColor;
float4 Tex2DNormal0=float4(UnpackNormal( tex2D(_Normal,(IN.uv_Normal.xyxy).xy)).xyz, 1.0 );
float4 TexCUBE0=texCUBE(_Cube,float4( IN.simpleWorldRefl.x, IN.simpleWorldRefl.y,IN.simpleWorldRefl.z,1.0 ));
float4 Multiply1=TexCUBE0 * _RefMultiply.xxxx;
float4 Fresnel0_1_NoInput = float4(0,0,1,1);
float4 Fresnel0=(1.0 - dot( normalize( float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 ).xyz), normalize( Fresnel0_1_NoInput.xyz ) )).xxxx;
float4 Pow0=pow(Fresnel0,_RefFresnel.xxxx);
float4 Multiply2=Multiply1 * Pow0;
float4 Tex2D2=tex2D(_SpecularMap,(IN.uv_SpecularMap.xyxy).xy);
float4 Multiply7=Tex2D2 * _SpecularMultiply.xxxx;
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Multiply4;
o.Normal = Tex2DNormal0;
o.Emission = Multiply2;
o.Specular = _SpecularFalloff.xxxx;
o.Gloss = Multiply7;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}