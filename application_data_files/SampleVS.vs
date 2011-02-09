float4x4 WorldViewProj;


struct VS_INPUT
{
  float4 Pos : POSITION;
  float3 Normal : NORMAL;
  float4 Diffuse : COLOR0;
};

struct VS_OUTPUT
{
  float4 Pos : POSITION;
  float4 Diffuse : COLOR0;
};


void MainVS(VS_INPUT In, out VS_OUTPUT Out)
{
  Out.Pos = mul(In.Pos, WorldViewProj);
  Out.Diffuse = In.Diffuse;
}
