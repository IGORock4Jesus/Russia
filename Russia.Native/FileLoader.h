#pragma once

#include <fstream>
#include <vector>
#include <Windows.h>

class FileLoader {
public:
	const std::vector<uint8_t>& Load(LPCTSTR filename);
};

