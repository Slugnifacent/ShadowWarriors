
sampler tex : register (s0);
float2 CameraMovement;

float4 PixelShaderFunction(float2 texCoord: TEXCOORD0) : COLOR0
{
	float4 Color = tex2D(tex, texCoord);
    return Color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
