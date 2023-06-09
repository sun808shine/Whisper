﻿static class ShaderNames
{
	public static void write( string path, IEnumerable<string> names )
	{
		string[] arr = names.ToArray();
		using var stream = File.CreateText( path );
		stream.WriteLine( @"// This source file is generated by a tool
#include ""stdafx.h""
#include ""shaderNames.h""
" );

		stream.WriteLine( "static const std::array<const char*, {0}> s_shaderNames = ", arr.Length );
		stream.WriteLine( "{" );
		foreach( string name in arr )
			stream.WriteLine( @"	""{0}"",", name );

		stream.Write( @"};

const char* DirectCompute::computeShaderName( eComputeShader cs )
{
	const uint16_t i = (uint16_t)cs;
	if( i < s_shaderNames.size() )
		return s_shaderNames[ i ];
	return nullptr;
}" );
	}
}