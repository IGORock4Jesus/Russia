#pragma once

#include <wrl.h>
#include <D3D11.h>

HRESULT InitializeRenderer(HWND hwnd, int width, int height);
void ReleaseRenderer();

Microsoft::WRL::ComPtr<ID3D11Device> GetDevice();

