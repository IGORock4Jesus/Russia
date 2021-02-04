#include "VertexShader.h"
#include "FileLoader.h"


HRESULT VertexShader::Initialize(const ComPtr<ID3D11Device>& device, LPCTSTR filename) {
    FileLoader loader;
    auto shaderCode = loader.Load(filename);
    if (shaderCode.empty()) {
        return APPX_E_MISSING_REQUIRED_FILE;
    }

    HRESULT result = S_OK;
    if (FAILED(result = device->CreateVertexShader(shaderCode.data(), shaderCode.size(), nullptr, shader.GetAddressOf()))) {
        return result;
    }

    return result;
}

HRESULT VertexShader::Render(const ComPtr<ID3D11DeviceContext>& deviceContext) {
     deviceContext->VSSetShader(shader.Get(), nullptr, 0);
     return S_OK;
}
