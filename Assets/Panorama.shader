Shader "Unlit/PanoramaShader"
{
	Properties{
		[PerRendererData]_MainTex("Main texture (RGB)", 2D) = "white" {}
		[PerRendererData]_MainOrientation("Main orientation (Quat)", Vector) = (0.0, 0.0, 0.0, 1.0)
		[PerRendererData]_NextTex("Transition texture (RGB)", 2D) = "white" {}
		[PerRendererData]_NextOrientation("Next orientation (Quat)", Vector) = (0.0, 0.0, 0.0, 1.0)
		[PerRendererData]_Transition("Transition", Range(0.0, 1.0)) = 0
		_Rotation("Rotation", float) = -90
	}

	SubShader{
		Tags { "Queue" = "Background" "RenderType" = "Background"}

		Cull Front ZWrite On

		Pass {
			// ZTest Always
			Fog { Mode off }

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _NextTex;

			float4 _MainOrientation;
			float4 _NextOrientation;

			float _Transition;
			float _Rotation;

			struct appdata_t {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float3 texcoord : TEXCOORD0;
			};

			float4 multiply(float4 q1, float4 q2) {
				return float4(
					q1.w * q2.x + q1.x * q2.w + q1.z * q2.y - q1.y * q2.z,
					q1.w * q2.y + q1.y * q2.w + q1.x * q2.z - q1.z * q2.x,
					q1.w * q2.z + q1.z * q2.w + q1.y * q2.x - q1.x * q2.y,
					q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z
				);
			}

			float3 rotateVector(float4 quat, float3 vec) {
				float4 qv = multiply(quat, float4(vec, 0.0));
				return multiply(qv, float4(-quat.x, -quat.y, -quat.z, quat.w)).xyz;
			}

			float2 calculateUV(float3 direction, float4 orientation) {
				direction = rotateVector(orientation, direction);

				float2 longlat = float2(atan2(direction.x, direction.z), acos(-direction.y));
				float2 uv = longlat / float2(2.0 *  UNITY_PI, UNITY_PI);
				uv.x += 0.5;

				return uv;
			}

			v2f vert(appdata_t v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.vertex.xyz;

				float s = sin((_Rotation / 180) *  UNITY_PI);
				float c = cos((_Rotation / 180) *  UNITY_PI);

				float2x2 rotationMatrix = float2x2(c, -s, s, c);
				rotationMatrix *= 0.5;
				rotationMatrix += 0.5;
				rotationMatrix = rotationMatrix * 2 - 1;
				o.texcoord.xz = mul(o.texcoord.xz, rotationMatrix);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				float3 dir = normalize(i.texcoord);

				half4 tex = tex2D(_MainTex, calculateUV(dir, _MainOrientation));
				if (_Transition > 0.0) {
					half4 nextTex = tex2D(_NextTex, calculateUV(dir, _NextOrientation));

					tex = (1.0 - _Transition) * tex + _Transition * nextTex;
				}

				return tex;
			}

			ENDCG
		}
	}

	Fallback Off
}