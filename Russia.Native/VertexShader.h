#pragma once

#include <D3D11.h>
#include <wrl.h>
#include <string>

using namespace Microsoft::WRL;


class VertexShader {
	ComPtr<ID3D11VertexShader> shader;

public:
	HRESULT Initialize(const ComPtr<ID3D11Device>& device, LPCTSTR filename);
	HRESULT Render(const ComPtr<ID3D11DeviceContext>& deviceContext);
};

